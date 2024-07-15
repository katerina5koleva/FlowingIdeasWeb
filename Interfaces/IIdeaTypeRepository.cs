using MyWebApp.Models;

namespace MyWebApp.Interfaces
{
    public interface IIdeaTypeRepository
    {
        Task<IEnumerable<IdeaType>> GetAll();
        Task<IdeaType> GetByIdAsync(int id);
        bool Add(IdeaType ideatype);
        bool Update(IdeaType ideatype);
        bool Delete(IdeaType ideaType);
        bool Save();
    }
}
