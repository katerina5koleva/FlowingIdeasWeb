using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebApp.Models;
using System.ComponentModel.DataAnnotations;

namespace MyWebApp.ViewModels
{
    public class CreateIdeaViewModel
    {
        [Required]
        public bool IsPublic { get; set; }
        [Required]
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
