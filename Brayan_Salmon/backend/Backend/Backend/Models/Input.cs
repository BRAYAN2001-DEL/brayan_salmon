using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Input
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Label { get; set; }

        public string Type { get; set; } // e.g., "text", "number"

        public int FormId { get; set; }

        public Form Form { get; set; }
    }
}
