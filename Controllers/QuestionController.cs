using QuestionPlatform2.Models;
using QuestionPlatform2.Repositories;
using QuestionPlatform2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace QuestionPlatform2.Controllers
{
    public class QuestionController : Controller
    {
        private readonly QuestionRepository _questionRepository;

        public QuestionController(QuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
        }

        public IActionResult Index()
        {
            var questions = _questionRepository.GetList();
            return View(questions);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(QuestionModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _questionRepository.Add(model);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var question = _questionRepository.GetById(id);
            return View(question);
        }

        [HttpPost]
        public IActionResult Update(QuestionModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _questionRepository.Update(model);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var question = _questionRepository.GetById(id);
            return View(question);
        }

        [HttpPost]
        public IActionResult Delete(QuestionModel model)
        {

            _questionRepository.Delete(model.Id);
            return RedirectToAction("Index");
        }
    }
}