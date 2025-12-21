using QuestionPlatform2.Models;

public class AnswerRepository : GenericRepository<Answer>
{
    public AnswerRepository(AppDbContext context) : base(context)
    {
    }
}
