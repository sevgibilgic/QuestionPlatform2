using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestionPlatform2.Models;
using QuestionPlatform2.Repositories;
using QuestionPlatform2.ViewModels;

namespace QuestionPlatform2.Controllers
{
    public class QuestionController : Controller
    {
        private readonly QuestionRepository _questionRepository;
        private readonly AnswerRepository _answerRepository;
        private readonly IMapper _mapper;
        public QuestionController(QuestionRepository questionRepository, AnswerRepository answerRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        // LIST
        public async Task<IActionResult> Index()
        {
            var questionEntities = await _questionRepository.GetAllAsync();
            var questionModels = _mapper.Map<List<QuestionModel>>(questionEntities);

            return View(questionModels);
        }


        // DETAILS (Question + Answers)
        public async Task<IActionResult> Details(int id)
        {
            var question = await _questionRepository
                .Where(x => x.Id == id)
                .Include(x => x.Answers)
                .FirstOrDefaultAsync();

            if (question == null)
                return NotFound();

            var model = _mapper.Map<QuestionModel>(question);
            return View(model);
        }


        // CREATE GET
        public IActionResult Add()
        {
            return View();
        }

        // CREATE POST
        [HttpPost]
        public async Task<IActionResult> Add(Question model)
        {
            if (!ModelState.IsValid)
                return View(model);

            await _questionRepository.AddAsync(model);
            return RedirectToAction("Index");
        }

        // EDIT GET
        public async Task<IActionResult> Update(int id)
        {
            var question = await _questionRepository.GetByIdAsync(id);
            if (question == null)
                return NotFound();

            var model = _mapper.Map<QuestionModel>(question);
            return View(model);
        }

        // EDIT POST
        [HttpPost]
        public async Task<IActionResult> Update(QuestionModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var entity = _mapper.Map<Question>(model);
            await _questionRepository.UpdateAsync(entity);

            return RedirectToAction("Index");
        }

        // DELETE
        public async Task<IActionResult> Delete(int id)
        {
            await _questionRepository.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
