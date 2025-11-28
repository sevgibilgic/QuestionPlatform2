using QuestionPlatform2.Models;

namespace QuestionPlatform2.Repositories
{
    public class QuestionRepository
    {
        private readonly AppDbContext _context;

        public QuestionRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Question> GetList()
        {
            var questions = _context.Questions.ToList();
            return questions;
        }
        public Question GetById(int id)
        {
            var question = _context.Questions.Where(s => s.Id == id).FirstOrDefault();
            return question;
        }
        public void Add(Question model)
        {
            _context.Questions.Add(model);
            _context.SaveChanges();
        }
        public void Update(Question model)
        {
            var question = GetById(model.Id);
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
            var product = GetById(id);
            if (product != null)
            {
                _context.Questions.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}