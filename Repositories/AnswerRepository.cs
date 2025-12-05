using QuestionPlatform2.Models;

namespace QuestionPlatform2.Repositories
{
    public class AnswerRepository : GenericRepository<Answer>
    {
        public AnswerRepository(AppDbContext context) : base(context)
        {
        }
    }
}
