using System;

namespace StudyLab.Models.Dtos
{
    public class MessageDto
    {
        public int Id { get; set; }

        public string MessageText { get; set; }
        public string SubjectText { get; set; }

        public DateTime DateTimeSent { get; set; }

        public string SenderId { get; set; }

        public string RecieverId { get; set; }

        public string RecieverUsername { get; set; }

    }
}