using Microsoft.EntityFrameworkCore;
using Tcg_web.Data;
using Tcg_web.Models;
using Tcg_web.Repository.Interfaces;

namespace Tcg_web.Repository
{
    // Repository for Card entity
    public class CardRepository : ICardRepository
    {
        // Dependency Injection of DataContext
        private readonly DataContext _context;
        public CardRepository(DataContext context)
        {
            _context = context;
        }

        // Get all cards with their Type and Rarity included
        public async Task<List<Card>> GetAllCards()
        {
            return await _context.Cards
                .Include(c => c.Type)
                .Include(c => c.Rarity)
                .OrderBy(p => p.Id)
                .ToListAsync();
        }
    }
}
