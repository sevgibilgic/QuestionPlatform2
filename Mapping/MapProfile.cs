using AutoMapper;
using QuestionPlatform2.Models;
using QuestionPlatform2.ViewModels;

namespace QuestionPlatform2.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Question, QuestionModel>().ReverseMap();
            CreateMap<Answer, AnswerModel>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, RegisterModel>().ReverseMap();
        }
    }
}