using QuestionPlatform2.Models;
using QuestionPlatform2.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
        }

        public IActionResult Index()
        {
            var questions = _questionRepository.GetList();
            var answer = _answerRepository.GetList();
            questions = questions.Where(s => s.IsActive == true).ToList();
            return View();
        }


        public IActionResult TestWithLayout()
        {
            return View();
        }

        public IActionResult TestWithOutLayout()
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
