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
    }
}