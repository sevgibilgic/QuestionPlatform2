using QuestionPlatform2.Models;
using QuestionPlatform2.ViewModels;

namespace QuestionPlatform2.Repositories
{
    public class AnswerRepository
    {
        private readonly AppDbContext _context;

        public AnswerRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<AnswerModel> GetList()
        {
            var answer = _context.Answers.Select(x => new AnswerModel()
            {
                Id = x.Id,
                AnswerContent = x.AnswerContent,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            }).ToList();

            return answer;
        }
        public AnswerModel GetById(int id)
        {
            var answer = _context.Answers.Where(s => s.Id == id).Select(x => new AnswerModel()
            {
                Id = x.Id,
                AnswerContent = x.AnswerContent,
                CreatedAt = x.CreatedAt,
                UpdatedAt = x.UpdatedAt
            }).FirstOrDefault();

            return answer;
        }
        public void Add(AnswerModel model)
        {
            var answer = new Answer()
            {
                AnswerContent = model.AnswerContent,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now

            };
            _context.Answers.Add(answer);
            _context.SaveChanges();
        }
        public void Update(AnswerModel model)
        {
            var answer = _context.Answers.Where(s => s.Id == model.Id).FirstOrDefault();
            if (answer != null)
            {
                answer.AnswerContent = model.AnswerContent;
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