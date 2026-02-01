using Tcg_web.Helpers;
using Tcg_web.Models;

namespace Tcg_web.Repository.Interfaces
{
    // Interface for Card Repository
    public interface ICardRepository
    {
        Task<PagedList<Card>> GetAllCards(QueryObject query); // Get all cards
        Task<List<Card>> GetCards(int amount, int SetId); // Get a specific number of cards from a set
        Task<Set?> GetSet(int setId); // Get a set by its ID
        Task<List<Package>> GetPackageBySet(int setId); // Get a package of cards from a set
    }
}
