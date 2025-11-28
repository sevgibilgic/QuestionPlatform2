using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QuestionPlatform2.Models;

namespace QuestionPlatform2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QuestionRepository _questionRepository;
        private readonly AnswerRepository _answerRepository;
        public HomeController(ILogger<HomeController> logger, QuestionRepository questionRepository, AnswerRepository answerRepository)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
