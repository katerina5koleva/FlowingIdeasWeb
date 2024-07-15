using Microsoft.EntityFrameworkCore;
using MyWebApp.Data;
using MyWebApp.Interfaces;
using MyWebApp.Models;
using System.Linq;

namespace MyWebApp.Repository
{
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

        public async Task<IEnumerable<Idea>> GetAll()
        {
            return await _context.Ideas.Include(i => i.Type)
                                        .Include(i => i.IdenityUser)
                                        .ToListAsync();
        }

        public async Task<IEnumerable<Idea>> GetAllVisible()
        {
            return await _context.Ideas.Include(i => i.Type)
                                        .Include(i => i.IdenityUser)
                                       .Where(i => i.IsPublic == true)
                                       .ToListAsync();
        }

        public async Task<Idea> GetByIdAsync(int id)
        {
            return await _context.Ideas.Include(i => i.Type)
                                        .Include(i => i.IdenityUser)
                                       .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<IEnumerable<Idea>> GetByIdeaType(int ideaTypeId)
        {
            return await _context.Ideas
                .Include(i => i.IdenityUser)
                .Where(i => i.Type.Id == ideaTypeId)
                .ToListAsync(); ;
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
