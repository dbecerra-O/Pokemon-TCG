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
                .ToListAsync();
        }

        // Method to add cards to user collection
        public async Task AddCards(string username, List<Card> newCards)
        {
            var user = await _context.Users
                .Include(u => u.Collections)
                .ThenInclude(c => c.Card)
                .FirstOrDefaultAsync(u => u.Username == username);

            if (user == null) return;
            user.Collections ??= new List<Collection>();
            var groupedCards = newCards.GroupBy(c => c.Id).ToList();

            foreach(var group in groupedCards)
            {
                var cardId = group.Key;
                var quantityToSum = group.Count();
                var cardReference = group.First();

                var collectionEntry = user.Collections
                    .FirstOrDefault(c => c.Card != null && c.Card.Id == cardId);
                
                if (collectionEntry == null)
                {
                    collectionEntry.Quantity = quantityToSum;
                    collectionEntry.Updated_at = DateTime.Now;
                }
                else
                {
                    var newEntry = new Collection
                    {
                        User = user,
                        Card = cardReference,
                        Quantity = quantityToSum,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now
                    };

                    await _context.Collections.AddAsync(newEntry);
                    user.Collections.Add(newEntry);
                }
            }
            await _context.SaveChangesAsync();
        }

    }
}
