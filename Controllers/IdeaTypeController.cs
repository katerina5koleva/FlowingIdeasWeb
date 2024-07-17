using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Interfaces;
using MyWebApp.Models;
using MyWebApp.ViewModels;

namespace MyWebApp.Controllers
{
    [Authorize]
    public class IdeaTypeController : Controller
    {
        private readonly IHttpContextAccessor _httpsContextAccessor;
        private readonly IIdeaTypeRepository _ideaTypeRepository;

        public IdeaTypeController(IIdeaTypeRepository ideaTypeRepository, IHttpContextAccessor httpsContextAccessor)
        {
            _ideaTypeRepository = ideaTypeRepository;
            _httpsContextAccessor = httpsContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<IdeaType> ideaTypes = await _ideaTypeRepository.GetAll();
            return View(ideaTypes);
        }

        public async Task<IActionResult> Detail(int id)
        {
            IdeaType ideaType = await _ideaTypeRepository.GetByIdAsync(id);
            return View(ideaType);
        }

        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateIdeaTypeViewModel ideaTypeVM)
        {
            if (!ModelState.IsValid)
            {
                return View(ideaTypeVM);
            }
            IdeaType ideaType = new IdeaType
            {
                Title = ideaTypeVM.Title,
                Description = ideaTypeVM.Description,
                Color = ideaTypeVM.Color
            };
            _ideaTypeRepository.Add(ideaType);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int id)
        {
            IdeaType ideaType = await _ideaTypeRepository.GetByIdAsync(id);
            if (ideaType == null)
            {
                return View("Error");
            }
            EditIdeaTypeViewModel editIdeaTypeVM = new EditIdeaTypeViewModel
            {
                Id = ideaType.Id,
                Title = ideaType.Title,
                Description = ideaType.Description,
                Color = ideaType.Color
            };
            return View(editIdeaTypeVM);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditIdeaTypeViewModel editIdeaTypeVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Failed to edit idea type.");
                return View(editIdeaTypeVM);
            }

            IdeaType ideaType = await _ideaTypeRepository.GetByIdAsync(editIdeaTypeVM.Id);
            if (ideaType == null)
            {
                return View("Error");
            }

            ideaType.Title = editIdeaTypeVM.Title;
            ideaType.Description = editIdeaTypeVM.Description;
            ideaType.Color = editIdeaTypeVM.Color;

            _ideaTypeRepository.Update(ideaType);

            return RedirectToAction("Index");
        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int id)
        {
            IdeaType ideaType = await _ideaTypeRepository.GetByIdAsync(id);
            if (ideaType == null)
            {
                return View("Error");
            }
            return View(ideaType);
        }

        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteIdeaType(int id)
        {
            IdeaType ideaType = await _ideaTypeRepository.GetByIdAsync(id);
            if (ideaType == null)
            {
                return View("Error");
            }
            _ideaTypeRepository.Delete(ideaType);
            return RedirectToAction("Index");
        }
    }
}
