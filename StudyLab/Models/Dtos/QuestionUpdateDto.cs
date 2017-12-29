using System.ComponentModel.DataAnnotations;

namespace StudyLab.Models.Dtos
{
    public class QuestionUpdateDto
    {
        [Required]
        public string QuestionText { get; set; }

        [Required]
        public string AnswerText { get; set; }

        [Required]
        [Range(1, 10, ErrorMessage = "Please enter a valid number.")]
        public int TypeId { get; set; }
    }
}