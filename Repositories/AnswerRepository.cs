using AutoMapper;
using QuestionPlatform2.Models;
using QuestionPlatform2.ViewModels;

namespace QuestionPlatform2.Repositories
{
    public class AnswerRepository : GenericRepository<Answer>
    {
        public AnswerRepository(AppDbContext context) : base(context) { }

        internal void Add(AnswerModel model)
        {
            throw new NotImplementedException();
        }

        internal void Update(AnswerModel model)
        {
            throw new NotImplementedException();
        }
    }
}