using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using StudyLab.Models;
using StudyLab.Models.Dtos;
using StudyLab.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace StudyLab.Controllers.API
{
    public class QuestionController : ApiController
    {
        private readonly IQuestionRepository _repository;

        public QuestionController(IQuestionRepository repository)
        {
            _repository = repository;
        }

        [System.Web.Http.HttpGet] // Specifies the HTTP method
        [System.Web.Http.Route("api/questions/{tId}")] // Specifies the route URI using attribute routing

        public IHttpActionResult GetAllQuestions([FromUri]string tId)
        {
            var questions = _repository.GetQuestions(tId); // Get a list of all the questions with the TypeId

            if (!questions.Any()) // If the list returned contains no elements
                return NotFound(); // Return not found status code

            var results = Mapper.Map<IEnumerable<QuestionDto>>(questions); // Map Question object(s) to a QuestionDTO

            return Ok(results); // If no errors are found anywhere above, return 200 OK status code and return results.
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("api/questions/{tId}/{id}", Name = "GetQuestion")]
        public IHttpActionResult GetQuestion([FromUri]int id, string tId)
        {

            var entity = _repository.GetQuestion(id, tId);

            var result = Mapper.Map<QuestionDto>(entity);

            if (entity == null)
                return NotFound();

            return Ok(result);
        }

        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("api/questions/{tId}/{id}")]

        public IHttpActionResult DeleteQuestion([FromUri]int id, string tId)
        {
            if (id == 0)
                NotFound();

            _repository.DeleteQuestion(id, tId);

            if (!ModelState.IsValid)
                BadRequest();

            if (!_repository.Save())
                return BadRequest();

            return Ok();

        }

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("api/questions")]
        public IHttpActionResult AddQuestion([FromBody]IEnumerable<QuestionCreateDto> dto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var temp = new List<Question>();

            foreach (var question in dto)
            {
                temp.Add(Mapper.Map<Question>(question)); ;
            }

            //var result = Mapper.Map<Question>(dto);

            if (!temp.Any())
                return NotFound();

            _repository.AddQuestion(temp);


            if (!_repository.Save())
                return BadRequest();

            //return CreatedAtRoute("GetQuestion", new { id = result.Id, tId = result.TypeId }, result);
            return Ok();
        }

        [System.Web.Http.HttpPatch]
        [System.Web.Http.Route("api/questions/{tId}/{id}")]
        public IHttpActionResult UpdateQuestion(int id, string tId, [FromBody]JsonPatchDocument<QuestionUpdateDto> dto)
        {
            if (!ModelState.IsValid) // Check if the dto model state is valid
                return BadRequest(); // If not, return a BadRequest status code as the response

            var result = Mapper.Map<JsonPatchDocument<Question>>(dto); // Map the QuestionUpdateDto to Question

            if (result == null) // If the return mapping is null
                return BadRequest(); // Return a BadRequest status code

            _repository.UpdateQuestion(id, tId, result); // Make a call to the QuestionRepo interface/contract

            if (!_repository.Save()) // If updating the database context fails
                return InternalServerError(); // Return status code 500, internal server error

            return Ok(); // If no errors happen anywhere within this code, return Ok and the updated result

        }
    }
}
