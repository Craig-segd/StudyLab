using AutoMapper;
using StudyLab.Models.Dtos;
using StudyLab.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace StudyLab.Controllers.API
{
    public class TypeController : ApiController
    {
        private readonly IQuestionRepository _repository;

        public TypeController(IQuestionRepository repository)
        {
            _repository = repository;
        }
        [HttpGet]
        [Route("api/types")]
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
