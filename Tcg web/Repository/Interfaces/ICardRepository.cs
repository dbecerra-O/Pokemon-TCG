using Tcg_web.Models;

namespace Tcg_web.Repository.Interfaces
{
    // Interface for Card Repository
    public interface ICardRepository
    {
        Task<List<Card>> GetAllCards(); // Get all cards
    }
}
