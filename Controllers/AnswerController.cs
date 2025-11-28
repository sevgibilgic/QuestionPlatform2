using QuestionPlatform2.Models;
using QuestionPlatform2.Repositories;
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
            var products = _answerRepository.GetList();
            return View(products);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Answer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _answerRepository.Add(model);
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var product = _answerRepository.GetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Answer model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _answerRepository.Update(model);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var product = _answerRepository.GetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Answer model)
        {

            _answerRepository.Delete(model.Id);
            return RedirectToAction("Index");
        }
    }
}