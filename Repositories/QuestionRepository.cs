using QuestionPlatform2.Models;

public class QuestionRepository : GenericRepository<Question>
{
    public QuestionRepository(AppDbContext context) : base(context)
    {
    }

}
