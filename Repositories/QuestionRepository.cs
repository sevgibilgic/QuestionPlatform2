using QuestionPlatform2.Models;
using QuestionPlatform2.ViewModels;

namespace QuestionPlatform2.Repositories
{
    public class QuestionRepository
    {
        private readonly AppDbContext _context;

        public QuestionRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<QuestionModel> GetList()
        {
            var question = _context.Questions.Select(x => new QuestionModel()
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                IsActive = x.IsActive,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            }).ToList();

            return question;
        }
        public QuestionModel GetById(int id)
        {
            var question = _context.Questions.Where(s => s.Id == id).Select(x => new QuestionModel()
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                IsActive = x.IsActive,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            }).FirstOrDefault();

            return question;
        }
        public void Add(QuestionModel model)
        {
            var question = new Question()
            {
                Title = model.Title,
                Content = model.Content,
                IsActive = model.IsActive,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now

            };
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