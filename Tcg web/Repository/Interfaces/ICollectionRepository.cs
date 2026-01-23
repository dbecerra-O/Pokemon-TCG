using Tcg_web.Models;

namespace Tcg_web.Repository.Interfaces
{
    // Interface for Collection Repository
    public interface ICollectionRepository
    {
        Task<List<Collection>> GetCollections(string username); // Get all collections for a user
    }
}
