using QuestionPlatform2.Models;

namespace QuestionPlatform2.Repositories
{
    public class FavoriteRepository : GenericRepository<Favorite>
    {
        public FavoriteRepository(AppDbContext context) : base(context)
        {
        }
    }
}
