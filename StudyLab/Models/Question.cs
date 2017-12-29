using System.ComponentModel.DataAnnotations;

namespace StudyLab.Models
{
    public class Question
    {
        // Primary key
        public int Id { get; set; }

        // Stores the question
        [Required]
        public string QuestionText { get; set; }

        // Stores the answer
        [Required]
        public string AnswerText { get; set; }

        // A Type datatype containing properties for types
        public Type Type { get; set; }

        // Used as a foreign key
        [Range(1, 10)]
        public int TypeId { get; set; }

    }
}