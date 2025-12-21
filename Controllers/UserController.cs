using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using QuestionPlatform2.Models;
using QuestionPlatform2.ViewModels;

namespace QuestionPlatform2.Controllers
{
    [Authorize(Roles = "User")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;

        public UserController(
            UserManager<ApplicationUser> userManager,
            IMapper mapper,
            INotyfService notyf)
        {
            _userManager = userManager;
            _mapper = mapper;
            _notyf = notyf;
        }

        
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return Unauthorized();

            var model = _mapper.Map<UserModel>(user);
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
    }
}
