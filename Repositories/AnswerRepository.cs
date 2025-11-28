using QuestionPlatform2.Models;
namespace QuestionPlatform2.Repositories
{
    public class AnswerRepository
    {
        private readonly AppDbContext _context;

        public AnswerRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Answer> GetList()
        {
            var answers = _context.Answers.ToList();
            return answers;
        }
        public Answer GetById(int id)
        {
            var answer = _context.Answers.Where(s => s.Id == id).FirstOrDefault();
            return answer;
        }
        public void Add(Answer model)
        {
            _context.Answers.Add(model);
            _context.SaveChanges();
        }
        public void Update(Answer model)
        {
            var answer = GetById(model.Id);
            if (answer != null)
            {
                answer.Content = model.Content;
                answer.CreatedAt = model.CreatedAt;
                answer.UpdatedAt = model.UpdatedAt;

                _context.Answers.Update(answer);
                _context.SaveChanges();
            }
        }
        public void Delete(int id)
        {
            var answer = GetById(id);
            if (answer != null)
            {
                _context.Answers.Remove(answer);
                _context.SaveChanges();
            }
        }
    }
}