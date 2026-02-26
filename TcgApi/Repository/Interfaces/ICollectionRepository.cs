using TcgApi.Models;

namespace TcgApi.Repository.Interfaces
{
    // Interface for Collection Repository
    public interface ICollectionRepository
    {
        Task<List<Collection>> GetCollections(string username); // Get all collections for a user
        Task<User?> GetUserWithCollection(string username); // Add new cards to a user's collection
    }
}
