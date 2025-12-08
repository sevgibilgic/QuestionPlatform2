using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuestionPlatform2.Repositories;
using QuestionPlatform2.Models;

namespace YourProject.Controllers
{
    [Authorize(Roles = "Admin")] 
    public class AdminController : Controller
    {
        private readonly UserRepository _userRepository;

        public AdminController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IActionResult Users()
        {
            var users = _userRepository.GetAllUsers();
            return View(users);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
