using System.Security.Claims;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using NETCore.Encrypt.Extensions;
using QuestionPlatform2.Models;
using QuestionPlatform2.Repositories;
using QuestionPlatform2.ViewModels;

namespace QuestionPlatform2.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly INotyfService _notyf;

        public HomeController(UserRepository userRepository, IMapper mapper, INotyfService notyf)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _notyf = notyf;
        }

        public IActionResult Login() => View();
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            if (await _userRepository.ExistsByUserName(model.UserName))
            {
                _notyf.Error("Kullanıcı adı kayıtlı!");
                return View(model);
            }

            if (await _userRepository.ExistsByEmail(model.Email))
            {
                _notyf.Error("E-posta adresi kayıtlı!");
                return View(model);
            }

            var user = _mapper.Map<User>(model);
            user.Password = HashPassword(model.Password);
            user.Role = "User";
            user.Created = DateTime.Now;
            user.Updated = DateTime.Now;

            if (model.PhotoFile != null && model.PhotoFile.Length > 0)
            {
                var fileName = Guid.NewGuid() + Path.GetExtension(model.PhotoFile.FileName);
                var path = Path.Combine("wwwroot/uploads/", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await model.PhotoFile.CopyToAsync(stream);
                }

                user.PhotoUrl = "/uploads/" + fileName;
            }
            else
            {
                user.PhotoUrl = "/uploads/default.jpg"; // NULL gitmesin
            }


            await _userRepository.AddAsync(user);

            _notyf.Success("Kayıt başarılı! Giriş yapabilirsiniz.");
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await _userRepository.GetByUserName(model.UserName);
            if (user == null || !VerifyPassword(user.Password, model.Password))
            {
                _notyf.Error("Kullanıcı adı veya parola hatalı!");
                return View(model);
            }

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.Role, user.Role)
    };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties { IsPersistent = model.KeepMe }
            );

            if (user.Role == "Admin")
                return RedirectToAction("Index", "Admin");

            return RedirectToAction("Index", "User");
        }


        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        private string HashPassword(string password)
        {
            return password.MD5();
        }

        private bool VerifyPassword(string hashed, string plain)
        {
            return hashed == plain.MD5();
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
