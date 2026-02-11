using Microsoft.EntityFrameworkCore;
using Tcg_web.Data;
using Tcg_web.Helpers;
using Tcg_web.Models;
using Tcg_web.Repository.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        public async Task<PagedList<Card>> GetAllCards(QueryObject query)
        {
            var cardsQuery = _context.Cards
                .Include(c => c.Type)
                .Include(c => c.Rarity)
                .Include(c => c.EnergyType)
                .AsQueryable();

            if (query.Type != 0)
            {
                cardsQuery = cardsQuery.Where(c => c.TypeId == query.Type);
            }
            if (query.Rarity != 0)
            {
                cardsQuery = cardsQuery.Where(c => c.RarityId == query.Rarity);
            }
            if (query.EnergyType != 0)
            {
                cardsQuery = cardsQuery.Where(c => c.EnergyTypeId == query.EnergyType);
            }
            if (!string.IsNullOrWhiteSpace(query.SearchName))
            {
                cardsQuery = cardsQuery.Where(c => c.Name!.ToLower().Contains(query.SearchName.ToLower()));
            }

            cardsQuery = cardsQuery.OrderBy(c => c.Id);

            return await PagedList<Card>.CreateAsync(cardsQuery, query.PageNumber, query.PageSize);
        }

        // Get cards by SetId with random ordering
        public async Task<List<Card>> GetCards(int amount, int SetId)
        {
            return await _context.Cards
                .Where(c => c.SetId == SetId)
                .OrderBy(p => Guid.NewGuid())
                .Include(c => c.Type)
                .Include(c => c.Rarity)
                .Include(c => c.EnergyType)
                .Take(amount)
                .ToListAsync();
        }

        // Get a specific set by its Id
        public async Task<Set?> GetSet(int setId)
        {
            return await _context.Sets.FirstOrDefaultAsync(s => s.Id == setId);
        }

        // Get packages by SetId
        public async Task<List<Package>> GetPackageBySet(int setId)
        {
            return await _context.Packages.Where(c => c.SetId == setId).ToListAsync();
        }

        // Get all Types
        public Task<List<Models.Type>> GetTypes()
        {
            return _context.Types.OrderBy(c => c.Id).ToListAsync();
        }

        // Get all sets
        public Task<List<Set>> GetSets()
        {
            return _context.Sets.OrderBy(c => c.Id).ToListAsync();
        }

        // Get all rarities
        public Task<List<Rarity>> GetRarities()
        {
            return _context.Rarities.OrderBy(c => c.Id).ToListAsync();
        }

        // Get all energy types
        public Task<List<EnergyType>> GetEnergyTypes()
        {
            return _context.EnergyTypes.OrderBy(c => c.Id).ToListAsync();
        }
    }
}
