using System.ComponentModel.DataAnnotations;

namespace StudyLab.Models.Dtos
{
    public class QuestionDto
    {
        public int Id { get; set; }

        public string QuestionText { get; set; }

        public string AnswerText { get; set; }

        [Range(1, 10)]
        public int TypeId { get; set; }
    }
}