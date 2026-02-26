using Microsoft.EntityFrameworkCore;
using TcgApi.Data;
using TcgApi.Models;
using TcgApi.Repository.Interfaces;

namespace TcgApi.Repository
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
                .Include(c => c.Card)
                    .ThenInclude(card => card.EnergyType)
                .OrderBy(c => c.Card.EnergyTypeId)
                .ThenBy(c => c.Card.Id)
                .ToListAsync();
        }

        // Method to add cards to a user's collection
        public async Task<User?> GetUserWithCollection(string username)
        {
            return await _context.Users
                .Include(u => u.Collections)
                .ThenInclude(c => c.Card)
                .FirstOrDefaultAsync(u => u.Username == username);
        }

    }
}
