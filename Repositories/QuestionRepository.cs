using AutoMapper;
using QuestionPlatform2.Models;
using QuestionPlatform2.ViewModels;

namespace QuestionPlatform2.Repositories
{
    public class QuestionRepository : GenericRepository<Question>
    {
        public QuestionRepository(AppDbContext context) : base(context) { }
    }
}