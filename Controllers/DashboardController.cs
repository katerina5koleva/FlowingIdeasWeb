using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Interfaces;
using MyWebApp.Models;
using MyWebApp.ViewModels;

namespace MyWebApp.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly IDashboardRepository _dashboardRepository;
        public DashboardController(IDashboardRepository dashboardRepository)
        {
            _dashboardRepository = dashboardRepository;
        }
        public async Task<IActionResult> Index()
        {
            List<Idea> userIdeas = await _dashboardRepository.GetIdeasByUserId();
            DashboardViewModel dashboardVM = new DashboardViewModel
            {
                UserIdeas = userIdeas
            };
            return View(dashboardVM);
        }
    }
}
