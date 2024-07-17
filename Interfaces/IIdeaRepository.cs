using MyWebApp.Models;

namespace MyWebApp.Interfaces
{
    public interface IIdeaRepository
    {
        Task<IEnumerable<Idea>> GetAll();
        Task<Idea> GetByIdAsync (int id);
        Task<Idea> GetByIdUserChangesAsync(int id, string userId);
        Task<IEnumerable<Idea>> GetByIdeaType(int ideaTypeId);
        Task<IEnumerable<Idea>> GetAllVisible();
        bool Add(Idea idea);
        bool Update(Idea idea);
        bool Delete(Idea idea);
        bool Save();
    }
}
