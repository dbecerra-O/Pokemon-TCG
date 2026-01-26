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
                .Include(c => c.Card)
                    .ThenInclude(card => card.EnergyType)
                .ToListAsync();
        }

        public async Task AddCards(string username, List<Card> newCards)
        {
            var user = await _context.Users
                .Include(u => u.Collections)
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null) return;

            foreach (var card in newCards)
            {
                var collectionEntry = user.Collections
                    .FirstOrDefault(c => c.Id == card.Id);

                if (collectionEntry != null)
                {
                    collectionEntry.Quantity += 1;
                    collectionEntry.Updated_at = DateTime.Now;
                }
                else
                {
                    var newEntry = new Collection
                    {    
                        User = user,
                        Card = card,
                        Quantity = 1,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now
                    };
                    await _context.Collections.AddAsync(newEntry);
                }
            }

            await _context.SaveChangesAsync();
        }

    }
}
