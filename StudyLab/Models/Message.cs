using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudyLab.Models
{
    public class Message
    {
        public int Id { get; set; }

        public string MessageText { get; set; }

        public string SubjectText { get; set; }

        public DateTime? DateTimeSent { get; set; }

        [ForeignKey("Reciever")]
        public string RecieverId { get; set; }
        public ApplicationUser Reciever { get; set; }

        [ForeignKey("Sender")]
        public string SenderId { get; set; }
        public ApplicationUser Sender { get; set; }
    }
}