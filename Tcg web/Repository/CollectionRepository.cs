using Microsoft.EntityFrameworkCore;
using Tcg_web.Data;
using Tcg_web.Models;
using Tcg_web.Repository.Interfaces;

namespace Tcg_web.Repository
{
    // Repository for Collection entity
    public class CollectionRepository : ICollectionRepository
    {
        // Dependency injection of DataContext
        private readonly DataContext _context;
        public CollectionRepository(DataContext context)
        {
            _context = context;
        }

        // Method to get collections for a specific user
        public async Task<List<Collection>> GetCollections(string username)
        {
            return await _context.Collections
                .Where(c => c.User.Username == username)
                .Include(c => c.Card)
                    .ThenInclude(card => card.Type)
                .Include(c => c.Card)
                    .ThenInclude(card => card.Rarity)
                .ToListAsync();
        }
    }
}
