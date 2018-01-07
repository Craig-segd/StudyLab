using StudyLab.Models;
using System.Collections.Generic;

namespace StudyLab.Services
{
    public interface IMessageRepository
    {
        IEnumerable<Message> RecieveMessages(string reciever);
        void SendMessage(Message dto);
        IEnumerable<ApplicationUser> GetUsers();
        bool Save();
        void DeleteMessage(int id);
        string GetRecieverUsername(string id);
        string GetRecieverId(string id);
    }
}
