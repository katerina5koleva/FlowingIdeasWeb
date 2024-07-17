using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Interfaces;
using MyWebApp.Models;
using System.Data;

namespace MyWebApp.Repository
{
    [Authorize]
    public class IdeaTypeRepository : IIdeaTypeRepository
    {
        private readonly ApplicationDbContext _context;
        public IdeaTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Administrator")]
        public bool Add(IdeaType ideaType)
        {
            _context.Add(ideaType);
            return Save();
        }
        [Authorize(Roles = "Administrator")]
        public bool Delete(IdeaType ideaType)
        {
            _context.Remove(ideaType);
            return Save();
        }

        public async Task<IEnumerable<IdeaType>> GetAll()
        {
            return await _context.IdeaTypes.ToListAsync();
        }

        public async Task<IdeaType> GetByIdAsync(int id)
        {
            return await _context.IdeaTypes.FirstOrDefaultAsync(i => i.Id == id);
        }
        [Authorize(Roles = "Administrator")]
        public bool Save()
        {
            int saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
        [Authorize(Roles = "Administrator")]
        public bool Update(IdeaType ideaType)
        {
            _context.Update(ideaType);
            return Save();
        }
    }
}
