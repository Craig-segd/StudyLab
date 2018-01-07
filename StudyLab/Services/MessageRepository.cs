using StudyLab.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudyLab.Services
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<Message> RecieveMessages(string reciever)
        {
            return _context.Messages.Where(c => c.Reciever.Id == reciever).ToList();
        }

        public void SendMessage(Message dto)
        {
            _context.Messages.Add(dto);
        }

        public IEnumerable<ApplicationUser> GetUsers()
        {
            return _context.Users.ToList();

        }

        public bool Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public void DeleteMessage(int id)
        {
            var result = _context.Messages.Single(c => c.Id == id);

            _context.Messages.Remove(result);
        }

        public string GetRecieverUsername(string id)
        {
            var temp = _context.Users.SingleOrDefault(c => c.Id == id);

            var result = temp?.UserName;
            return result;
        }

        public string GetRecieverId(string id)
        {
            var temp = _context.Users.First(c => c.UserName == id);

            var result = temp?.Id;
            return result;
        }
    }
}