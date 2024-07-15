using MyWebApp.Models;

namespace MyWebApp.Interfaces
{
    public interface IDashboardRepository
    {
        Task<List<Idea>> GetIdeasByUserId();
    }
}
