using System.Reflection;
using AspNetCoreHero.ToastNotification;
using AutoMapper;
using Internet_1.Localisation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using QuestionPlatform2.Hubs;
using QuestionPlatform2.Models;
using QuestionPlatform2.Repositories;

namespace QuestionPlatform2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<QuestionRepository>();
            builder.Services.AddScoped<AnswerRepository>();
            builder.Services.AddScoped<FavoriteRepository>();

            builder.Services.AddScoped(typeof(GenericRepository<>));
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("sqlCon"));
            });
            builder.Services.AddSingleton<IFileProvider>(new PhysicalFileProvider(Directory.GetCurrentDirectory()));
            builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
            builder.Services.AddNotyf(config =>
            {
                config.DurationInSeconds = 10;
                config.IsDismissable = true;
                config.Position = NotyfPosition.BottomRight;
            });
            builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
           .AddErrorDescriber<ErrorDescription>()
           .AddEntityFrameworkStores<AppDbContext>()
           .AddDefaultTokenProviders();
            builder.Services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = "/Home/Login";
                opt.LogoutPath = "/Home/Logout";
                opt.AccessDeniedPath = "/Home/AccessDenied";
                opt.ExpireTimeSpan = TimeSpan.FromDays(3);
                opt.SlidingExpiration = true;
            });

            builder.Services.AddSignalR();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Login}/{id?}");

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                SeedData.SeedAsync(services).GetAwaiter().GetResult();
            }

            app.MapHub<GeneralHub>("/general-hub");

            app.Run();
        }
    }
}
