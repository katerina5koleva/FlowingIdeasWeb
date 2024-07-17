using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.Debugger.Contracts;
using MyWebApp.Interfaces;
using MyWebApp.Models;
using MyWebApp.Repository;
using MyWebApp.ViewModels;
using System.Data;
using System.Security.Claims;

namespace MyWebApp.Controllers
{
    [Authorize]
    public class IdeaController : Controller
    {
        private readonly IHttpContextAccessor _httpsContextAccessor;
        private readonly IIdeaRepository _ideaRepository;
        private readonly IIdeaTypeRepository _ideaTypeRepository;
        public IdeaController(IIdeaRepository ideaRepository, IIdeaTypeRepository ideaTypeRepository, IHttpContextAccessor httpsContextAccessor)
        {
            _ideaRepository = ideaRepository;
            _ideaTypeRepository = ideaTypeRepository;
            _httpsContextAccessor = httpsContextAccessor;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index(int page = 0, int? ideaTypeId = null, string sortBy = "newest")
        {
            IEnumerable<Idea> ideas;
            IEnumerable<IdeaType> ideaTypes = await _ideaTypeRepository.GetAll();
            ViewBag.IdeaTypes = ideaTypes.ToList();
            ViewBag.SelectedIdeaTypeId = ideaTypeId.HasValue ? ideaTypeId.Value : 0;
            ViewBag.SortBy = sortBy;
            const int PageSize = 3;
            if (ideaTypeId.HasValue && ideaTypeId.Value != 0)
            {
                ideas = await _ideaRepository.GetByIdeaType(ideaTypeId.Value);
            }
            else
            {
                if (User.IsInRole("Administrator"))
                {
                    ideas = await _ideaRepository.GetAll();
                }
                else
                {
                    ideas = await _ideaRepository.GetAllVisible();
                }
            }
            if (sortBy == "oldest")
            {
                ideas = ideas.OrderBy(i => i.DateCreated);
            
            else
            {
                ideas = ideas.OrderByDescending(i => i.DateCreated);
            }
            var count = ideas.Count();

            var paginatedIdeas = ideas.Skip(page * PageSize).Take(PageSize).ToList();

            ViewBag.MaxPage = (int)Math.Ceiling((double)count / PageSize) - 1;
            ViewBag.Page = page;

            return View(paginatedIdeas);
        }
        [AllowAnonymous]
        public async Task<IActionResult> Detail(int id)
        {
            Idea idea = await _ideaRepository.GetByIdAsync(id);
            return View(idea);
        }
        public async Task<IActionResult> Create()
        {
            IEnumerable<IdeaType> ideaTypes = await _ideaTypeRepository.GetAll();
            ViewBag.IdeaTypes = ideaTypes.ToList();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateIdeaViewModel ideaVM)
        {
            if (!ModelState.IsValid)
            {
                return View(ideaVM);
            }
            var currentUser = _httpsContextAccessor.HttpContext.User.GetUserId();
            Idea idea = new Idea
            {
                UserId = currentUser,
                IsPublic = ideaVM.IsPublic,
                ShowOwner = ideaVM.ShowOwner,
                Title = ideaVM.Title,
                Type = await _ideaTypeRepository.GetByIdAsync(ideaVM.SelectedIdeaTypeId),
                Description = ideaVM.Description,
                DateCreated = DateTime.Now
            };

            _ideaRepository.Add(idea);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Edit(int id)
        {
            IEnumerable<IdeaType> ideaTypes = await _ideaTypeRepository.GetAll();
            ViewBag.IdeaTypes = ideaTypes.ToList();
            string userId = _httpsContextAccessor.HttpContext.User.GetUserId();
            Idea idea = await _ideaRepository.GetByIdUserChangesAsync(id, userId);
            if (idea == null)
            {
                ViewData["ErrorMessage"] = "A problem occurred while proceeding with your request. Access denied.";
                return View("Error");
            }
            EditIdeaViewModel editIdeaVM = new EditIdeaViewModel
            {
                Id = idea.Id,
                IsPublic = idea.IsPublic,
                ShowOwner = idea.ShowOwner,
                Title = idea.Title,
                SelectedIdeaTypeId = idea.Type.Id,
                Description = idea.Description,
                DateCreated = idea.DateCreated,
            };
            return View(editIdeaVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditIdeaViewModel editIdeaVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit idea.");
                return View(editIdeaVM);
            }
            string userId = _httpsContextAccessor.HttpContext.User.GetUserId();
            Idea idea = await _ideaRepository.GetByIdUserChangesAsync(editIdeaVM.Id, userId);
            if (idea == null)
            {
                ViewData["ErrorMessage"] = "A problem occurred while proceeding with your request. Access denied.";
                return View("Error");
            }
            idea.IsPublic = editIdeaVM.IsPublic;
            idea.ShowOwner = editIdeaVM.ShowOwner;
            idea.Type = await _ideaTypeRepository.GetByIdAsync(editIdeaVM.SelectedIdeaTypeId);
            idea.Title = editIdeaVM.Title;
            idea.Description = editIdeaVM.Description;
            idea.DateCreated = DateTime.Now;

            _ideaRepository.Update(idea);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            string userId = _httpsContextAccessor.HttpContext.User.GetUserId();
            IEnumerable<IdeaType> ideaTypes = await _ideaTypeRepository.GetAll();
            ViewBag.IdeaTypes = ideaTypes.ToList();
            Idea idea = await _ideaRepository.GetByIdUserChangesAsync(id, userId);
            if (idea == null)
            {
                ViewData["ErrorMessage"] = "A problem occurred while proceeding with your request. Access denied.";
                return View("Error");
            }
            return View(idea);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteIdea(int id)
        {
            string userId = _httpsContextAccessor.HttpContext.User.GetUserId();
            Idea idea = await _ideaRepository.GetByIdUserChangesAsync(id, userId);
            if (idea == null)
            {
                ViewData["ErrorMessage"] = "A problem occurred while proceeding with your request. Access denied.";
                return View("Error");
            }
            _ideaRepository.Delete(idea);
            return RedirectToAction("Index");
        }
    }
}
