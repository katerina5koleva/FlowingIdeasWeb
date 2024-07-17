using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Interfaces;
using MyWebApp.Models;
using System.Linq;

namespace MyWebApp.Repository
{
    [Authorize]
    public class IdeaRepository : IIdeaRepository
    {
        private readonly ApplicationDbContext _context;
        public IdeaRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(Idea idea)
        {
            _context.Add(idea);
            return Save();
        }

        public bool Delete(Idea idea)
        {
            _context.Remove(idea);
            return Save();
        }
        [Authorize(Roles = "Administrator")]
        public async Task<IEnumerable<Idea>> GetAll()
        {
            return await _context.Ideas.Include(i => i.Type)
                                        .Include(i => i.IdenityUser)
                                        .ToListAsync();
        }
        [AllowAnonymous]
        public async Task<IEnumerable<Idea>> GetAllVisible()
        {
            return await _context.Ideas.Include(i => i.Type)
                                        .Include(i => i.IdenityUser)
                                       .Where(i => i.IsPublic == true)
                                       .ToListAsync();
        }
        [AllowAnonymous]
        public async Task<Idea> GetByIdAsync(int id)
        {
            return await _context.Ideas.Include(i => i.Type)
                                        .Include(i => i.IdenityUser)
                                       .FirstOrDefaultAsync(i => i.Id == id);
        }
        [AllowAnonymous]
        public async Task<IEnumerable<Idea>> GetByIdeaType(int ideaTypeId)
        {
            return await _context.Ideas
                .Include(i => i.IdenityUser)
                .Where(i => i.Type.Id == ideaTypeId)
                .Where(i => i.IsPublic == true)
                .ToListAsync();
        }

        public async Task<Idea> GetByIdUserChangesAsync(int id, string userId)
        {
            return await _context.Ideas.Include(i => i.Type)
                                   .Where(i => i.Id == id && i.IdenityUser.Id == userId)
                                   .FirstOrDefaultAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(Idea idea)
        {
            _context.Update(idea);
            return Save();
        }
    }
}
