using AutoMapper;
using QuestionPlatform2.Models;
using QuestionPlatform2.ViewModels;

namespace QuestionPlatform2.Repositories
{
    public class QuestionRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public QuestionRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<QuestionModel> GetList()
        {
            var questions = _context.Questions.ToList();
            var questionModels = _mapper.Map<List<QuestionModel>>(questions);
            return questionModels;
        }

        public QuestionModel GetById(int id)
        {
            var question = _context.Questions.Where(s => s.Id == id).FirstOrDefault();
            var questionModel = _mapper.Map<QuestionModel>(question);
            return questionModel;
        }
        public void Add(QuestionModel model)
        {
            var question = _mapper.Map<Question>(model);
            _context.Questions.Add(question);
            _context.SaveChanges();
        }
        public void Update(QuestionModel model)
        {
            var question = _context.Questions.Where(s => s.Id == model.Id).FirstOrDefault();
            if (question != null)
            {
                question.Title = model.Title;
                question.Content = model.Content;
                question.IsActive = model.IsActive;
                question.ImageUrl = model.ImageUrl;
                question.UpdatedAt = DateTime.Now;

                _context.Questions.Update(question);
                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var question = _context.Questions.Where(s => s.Id == id).FirstOrDefault();
            if (question != null)
            {
                _context.Questions.Remove(question);
                _context.SaveChanges();
            }
        }
    }
}