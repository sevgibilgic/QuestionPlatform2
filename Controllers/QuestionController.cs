using QuestionPlatform2.Models;
using QuestionPlatform2.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace QuestionPlatform1.Controllers
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
            var products = _questionRepository.GetList();
            return View(products);
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Question model)
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
            var product = _questionRepository.GetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Update(Question model)
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
            var product = _questionRepository.GetById(id);
            return View(product);
        }

        [HttpPost]
        public IActionResult Delete(Question model)
        {

            _questionRepository.Delete(model.Id);
            return RedirectToAction("Index");
        }
    }
}