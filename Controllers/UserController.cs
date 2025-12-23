using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using QuestionPlatform2.Hubs;
using QuestionPlatform2.Models;
using QuestionPlatform2.ViewModels;

namespace QuestionPlatform2.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;
        private readonly IHubContext<GeneralHub> _hubContext;

        public UserController(
            UserManager<ApplicationUser> userManager,
            AppDbContext context,
            IMapper mapper,
            INotyfService notyf,
            IHubContext<GeneralHub> _hubContext)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _notyf = notyf;
            _hubContext = _hubContext;
        }

        
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var model = _mapper.Map<UserModel>(user);
            return View(model);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(UserModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var count = _userManager.Users.Count();
                await _hubContext.Clients.All.SendAsync("onUserAdded", count);

                return RedirectToAction("Index");
            }

            return View(model);
        }

        public async Task<IActionResult> Update()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var model = _mapper.Map<UserModel>(user);
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            _mapper.Map(model, user);

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    _notyf.Error(error.Description);

                return View(model);
            }

            _notyf.Success("Profil güncellendi!");
            return RedirectToAction(nameof(Index));
        }

        
        [HttpPost]
        public async Task<IActionResult> Delete()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            await _userManager.DeleteAsync(user);

            _notyf.Success("Hesap silindi!");
            return RedirectToAction("Login", "Home");
        }
        public async Task<IActionResult> MyQuestions()
        {
            var userId = int.Parse(_userManager.GetUserId(User));

            var questions = await _context.Questions
                .Where(q => q.UserId == userId)
                .ToListAsync();

            return View(questions);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult GetUserCount()
        {
            return Json(_userManager.Users.Count());
        }

    }
}
