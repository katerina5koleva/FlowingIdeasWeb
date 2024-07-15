using System.ComponentModel.DataAnnotations;

namespace MyWebApp.Models
{
    public class IdeaType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        public string Description { get; set; }
        [MaxLength(20)]
        public string Color { get; set; }
    }
}
