using Microsoft.AspNetCore.Identity;
using MyWebApp.Models;

namespace MyWebApp.ViewModels
{
    public class EditIdeaViewModel
    {
        public int Id { get; set; }
        public bool IsPublic { get; set; }
        public bool ShowOwner { get; set; }
        public int SelectedIdeaTypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
