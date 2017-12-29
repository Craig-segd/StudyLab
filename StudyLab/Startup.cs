using AutoMapper;
using Microsoft.Owin;
using Owin;
using StudyLab.Models;
using StudyLab.Models.Dtos;

[assembly: OwinStartupAttribute(typeof(StudyLab.Startup))]
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
            });
            ConfigureAuth(app);

        }
    }
}
