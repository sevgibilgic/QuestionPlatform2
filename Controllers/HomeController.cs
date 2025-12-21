using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuestionPlatform2.Models;
using QuestionPlatform2.ViewModels;

namespace QuestionPlatform2.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly INotyfService _notyf;

        public HomeController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            RoleManager<IdentityRole<int>> roleManager,
            INotyfService notyf)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _notyf = notyf;
        }

        public IActionResult Login()
            {
                return View();
            }
        public IActionResult Register()
            {
                return View();
            }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (model.Password != model.PasswordConfirm)
            {
                _notyf.Error("Parolalar eşleşmiyor!");
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                FullName = model.FullName,
                PhotoUrl = "/uploads/default.jpg"
            };

            
            if (model.PhotoFile != null && model.PhotoFile.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(model.PhotoFile.FileName);
                var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                if (!Directory.Exists(uploadFolder))
                    Directory.CreateDirectory(uploadFolder);

                var filePath = Path.Combine(uploadFolder, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.PhotoFile.CopyToAsync(stream);
                }

                user.PhotoUrl = "/uploads/" + fileName;
            }

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    _notyf.Error(error.Description);

                return View(model);
            }

            
            if (!await _roleManager.RoleExistsAsync("User"))
                await _roleManager.CreateAsync(new IdentityRole<int>("User"));

            await _userManager.AddToRoleAsync(user, "User");

            _notyf.Success("Kayıt başarılı! Giriş yapabilirsiniz.");
            return RedirectToAction(nameof(Login));
        }

        
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await _signInManager.PasswordSignInAsync(
                model.UserName,
                model.Password,
                model.KeepMe,
                lockoutOnFailure: false);

            if (!result.Succeeded)
            {
                _notyf.Error("Kullanıcı adı veya parola hatalı!");
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);

            if (await _userManager.IsInRoleAsync(user, "Admin"))
                return RedirectToAction("Index", "Admin");

            return RedirectToAction("Index", "User");
        }

        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        public IActionResult AccessDenied() => View();

        public IActionResult Privacy()
            {
               return View();
            }
        public IActionResult Index()
            {
                return View();
            }
    }
}
