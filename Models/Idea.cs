using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyWebApp.Models
{
    public class Idea
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser IdenityUser { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]
        public bool IsPublic { get; set; }
        public bool ShowOwner { get; set; }
        [Required]
        public IdeaType Type { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        
    }
}
