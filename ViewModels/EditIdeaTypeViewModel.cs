using System.ComponentModel.DataAnnotations;

namespace MyWebApp.ViewModels
{
    public class EditIdeaTypeViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [MaxLength(7)]
        [MinLength(7)]
        public string Color { get; set; }
    }
}
