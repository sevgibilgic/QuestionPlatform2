using QuestionPlatform2.Models;
using QuestionPlatform2.Repositories;
using QuestionPlatform2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace QuestionPlatform2.Controllers
{
    public class AnswerController : Controller
    {
        private readonly AnswerRepository _answerRepository;

        public AnswerController(AnswerRepository answerRepository)
        {
            _answerRepository = answerRepository;
        }

        public IActionResult Index()
        {
            var answers = _answerRepository.GetList();
            return View(answers);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AnswerModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _answerRepository.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var answer = _answerRepository.GetById(id);
            return View(answer);
        }

        [HttpPost]
        public IActionResult Update(AnswerModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            _answerRepository.Update(model);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var answer = _answerRepository.GetById(id);
            return View(answer);
        }

        [HttpPost]
        public IActionResult Delete(AnswerModel model)
        {
            _answerRepository.Delete(model.Id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var answer = _answerRepository.GetById(id);
            if (answer == null)
                return NotFound();

            return View(answer);
        }
    }
}
