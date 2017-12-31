using AutoMapper;
using StudyLab.Models.Dtos;
using StudyLab.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;

namespace StudyLab.Controllers.API
{
    public class TypeController : ApiController
    {
        private readonly IQuestionRepository _repository;

        public TypeController(IQuestionRepository repository)
        {
            _repository = repository;
        }
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/types")]
        [ValidateAntiForgeryToken]
        public IHttpActionResult GetTypes()
        {
            var list = _repository.GetTypes();

            if (!list.Any())
            {
                return NotFound();
            }

            var result = Mapper.Map<IEnumerable<TypeDto>>(list);

            return Ok(result);
        }
    }
}
