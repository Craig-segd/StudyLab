using AutoMapper;
using StudyLab.Models;
using StudyLab.Models.Dtos;
using StudyLab.Services;
using System;
using System.Web.Http;

namespace StudyLab.Controllers.API
{
    public class MessageController : ApiController
    {
        private readonly IMessageRepository _repository;

        public MessageController(IMessageRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("api/messages/{reciever}")]
        public IHttpActionResult RecieveMessages(string reciever)
        {
            var result = _repository.RecieveMessages(reciever);

            return Ok(result);
        }

        [HttpPost]
        [Route("api/messages")]
        public IHttpActionResult SendMessage(MessageDto dto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            dto.DateTimeSent = DateTime.Now;

            var result = Mapper.Map<Message>(dto);

            if (result == null)
                return BadRequest();

            _repository.SendMessage(result);

            if (!_repository.Save())
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
