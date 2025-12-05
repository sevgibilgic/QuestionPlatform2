using Microsoft.AspNetCore.Mvc;

namespace QuestionPlatform2.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
