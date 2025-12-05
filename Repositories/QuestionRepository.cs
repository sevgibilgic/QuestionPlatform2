using QuestionPlatform2.Models;

namespace QuestionPlatform2.Repositories
{
    public class QuestionRepository : GenericRepository<Question>
    {
        public QuestionRepository(AppDbContext context) : base(context)
        {
        }
    }
}
