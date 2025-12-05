using QuestionPlatform2.Models;

namespace QuestionPlatform2.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        internal async Task GetAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}