using AutoMapper;
using StudyLab.Models;
using StudyLab.Models.Dtos;
using StudyLab.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult GetUsers(string query = null)
        {
            var userQuery = _repository.GetUsers();

            if (!string.IsNullOrWhiteSpace(query))
                userQuery = userQuery
                    .Where(c => c.UserName.ToLower()
                        .Contains(query.ToLower()));

            var temp = new List<UserDto>(); // Temporary list of question objects

            foreach (var user in userQuery) // For each loop for interating through each question
            {
                temp.Add(Mapper.Map<UserDto>(user)); // Map each dto to a Question type
            }


            return Ok(temp);

            //return Ok(userQuery);

        }

        [HttpPost]
        [Route("api/messages")]
        public IHttpActionResult SendMessage(MessageDto dto)
        {

            if (!ModelState.IsValid)
                return BadRequest();

            var recieverId = _repository.GetRecieverId(dto.RecieverUsername);

            if (recieverId == null)
                return NotFound();

            dto.RecieverId = recieverId;
            dto.DateTimeSent = DateTime.Now;
            dto.RecieverUsername = _repository.GetRecieverUsername(dto.RecieverId);

            var result = Mapper.Map<Message>(dto);

            if (result == null)
                return BadRequest();

            _repository.SendMessage(result);

            if (!_repository.Save())
                return BadRequest();


            return Ok();
        }

        [HttpDelete]
        [Route("api/messages/{id}")]
        public IHttpActionResult DeleteMessage(int id)
        {
            _repository.DeleteMessage(id);

            if (!_repository.Save())
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
