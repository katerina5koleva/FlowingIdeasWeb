using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyWebApp.Models;

namespace MyWebApp.ViewModels
{
    public class CreateIdeaViewModel
    {
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public bool IsPublic { get; set; }
        public bool ShowOwner { get; set; }
        public int SelectedIdeaTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
