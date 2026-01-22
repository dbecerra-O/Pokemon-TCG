using Microsoft.EntityFrameworkCore;
using Tcg_web.Data;
using Tcg_web.Models;
using Tcg_web.Repository.Interfaces;

namespace Tcg_web.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly DataContext _context;
        public CardRepository(DataContext context)
        {
            _context = context;
        }
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
