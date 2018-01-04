using StudyLab.Models;
using System.Collections.Generic;

namespace StudyLab.Services
{
    public interface IMessageRepository
    {
        IEnumerable<Message> RecieveMessages(string reciever);
        void SendMessage(Message dto);
        bool Save();
    }
}
