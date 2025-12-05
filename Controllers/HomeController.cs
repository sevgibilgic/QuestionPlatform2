using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuestionPlatform2.Repositories;
using QuestionPlatform2.ViewModels;

namespace QuestionPlatform2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly QuestionRepository _questionRepository;
        private readonly AnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public HomeController(
            ILogger<HomeController> logger,
            QuestionRepository questionRepository,
            AnswerRepository answerRepository,
            IMapper mapper)
        {
            _logger = logger;
            _questionRepository = questionRepository;
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var questionEntities = await _questionRepository.GetAllAsync();
            var answerEntities = await _answerRepository.GetAllAsync();

            var questionModels = _mapper.Map<List<QuestionModel>>(questionEntities);
            var answerModels = _mapper.Map<List<AnswerModel>>(answerEntities);

            questionModels = questionModels.Where(q => q.IsActive).ToList();

            var vm = new HomePageModel
            {
                Questions = questionModels,
                Answers = answerModels
            };

            return View(vm);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
