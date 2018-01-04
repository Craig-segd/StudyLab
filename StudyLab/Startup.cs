using AutoMapper;
using Owin;
using StudyLab.Models;
using StudyLab.Models.Dtos;

namespace StudyLab
{
    public partial class Startup
    {

        public void Configuration(IAppBuilder app)
        {

            // Initialise AutoMapper
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Question, QuestionDto>();
                cfg.CreateMap<QuestionDto, Question>();
                cfg.CreateMap<Question, QuestionCreateDto>();
                cfg.CreateMap<QuestionCreateDto, Question>();
                cfg.CreateMap<Message, MessageDto>();
                cfg.CreateMap<MessageDto, Message>();
            });

            ConfigureAuth(app);

        }
    }
}
