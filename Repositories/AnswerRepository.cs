using AutoMapper;
using QuestionPlatform2.Models;
using QuestionPlatform2.ViewModels;

namespace QuestionPlatform2.Repositories
{
    public class AnswerRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AnswerRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<AnswerModel> GetList()
        {
            var answers = _context.Answers.ToList();
            var answerModels = _mapper.Map<List<AnswerModel>>(answers);
            return answerModels;
        }

        public AnswerModel GetById(int id)
        {
            var answer = _context.Answers.Where(s => s.Id == id).FirstOrDefault();
            var answerModel = _mapper.Map<AnswerModel>(answer);
            return answerModel;
        }
        public void Add(AnswerModel model)
        {
            var answer = _mapper.Map<Answer>(model);
            _context.Answers.Add(answer);
            _context.SaveChanges();
        }
        public void Update(AnswerModel model)
        {
            var answer = _context.Answers.Where(s => s.Id == model.Id).FirstOrDefault();
            if (answer != null)
            {
                answer.AnswerContent = model.AnswerContent;
                answer.UpdatedAt = DateTime.Now;

                _context.Answers.Update(answer);
                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var answer = _context.Answers.Where(s => s.Id == id).FirstOrDefault();
            if (answer != null)
            {
                _context.Answers.Remove(answer);
                _context.SaveChanges();
            }
        }
    }
}