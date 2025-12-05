using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuestionPlatform2.Models;
using QuestionPlatform2.Repositories;
using QuestionPlatform2.ViewModels;

namespace QuestionPlatform2.Controllers
{
    public class QuestionController : Controller
    {
        private readonly QuestionRepository _repo;
        private readonly IMapper _mapper;

        public QuestionController(QuestionRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var questions = _repo.GetList();
            var models = _mapper.Map<List<QuestionModel>>(questions);
            return View(models);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(QuestionModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var question = _mapper.Map<Question>(model);
            _repo.Add(question);

            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var question = _repo.GetById(id);
            var model = _mapper.Map<QuestionModel>(question);
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(QuestionModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var entity = _mapper.Map<Question>(model);
            _repo.Update(entity);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var question = _repo.GetById(id);
            var model = _mapper.Map<QuestionModel>(question);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(QuestionModel model)
        {
            _repo.Delete(model.Id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var question = _repo.GetById(id);
            if (question == null)
                return NotFound();

            var model = _mapper.Map<QuestionModel>(question);
            return View(model);
        }
    }

}