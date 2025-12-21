using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using QuestionPlatform2.Hubs;
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
        private readonly IHubContext<GeneralHub> _generalHub;

        public QuestionController(
            QuestionRepository questionRepository,
            AnswerRepository answerRepository,
            IMapper mapper,
            IHubContext<GeneralHub> generalHub)
        {
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _mapper = mapper;
            _generalHub = generalHub;
        }

        public async Task<IActionResult> Index()
        {
            var questions = await _questionRepository.GetAllAsync();
            var model = _mapper.Map<List<QuestionModel>>(questions);
            return View(model);
        }

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

        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(QuestionModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var question = _mapper.Map<Question>(model);
            question.CreatedAt = DateTime.Now;
            question.UpdatedAt = DateTime.Now;

            await _questionRepository.AddAsync(question);

            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Update(int id)
        {
            var question = await _questionRepository.GetByIdAsync(id);
            if (question == null)
                return NotFound();

            var model = _mapper.Map<QuestionModel>(question);
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Update(QuestionModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var entity = await _questionRepository.GetByIdAsync(model.Id);
            if (entity == null)
                return NotFound();

            _mapper.Map(model, entity);
            entity.UpdatedAt = DateTime.Now;

            await _questionRepository.UpdateAsync(entity);
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await _questionRepository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
