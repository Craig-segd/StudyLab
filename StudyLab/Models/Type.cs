using System.ComponentModel.DataAnnotations.Schema;

namespace StudyLab.Models
{
    public class Type
    {
        // Primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Category name
        public string Name { get; set; }
    }
}