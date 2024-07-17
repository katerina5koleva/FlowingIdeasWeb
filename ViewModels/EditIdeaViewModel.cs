using Microsoft.AspNetCore.Identity;
using MyWebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MyWebApp.ViewModels
{
    public class EditIdeaViewModel
    {
        public int Id { get; set; }
        public bool IsPublic { get; set; }
        public bool ShowOwner { get; set; }
        [Required]
        public int SelectedIdeaTypeId { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
