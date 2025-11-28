using Microsoft.AspNetCore.Mvc;

namespace QuestionPlatform2.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}