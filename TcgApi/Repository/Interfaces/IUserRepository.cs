using TcgApi.Models;

namespace TcgApi.Repository.Interfaces
{
    // Interface for User Repository
    public interface IUserRepository
    {
        Task<List<User>> GetUsers(); // Get all users
        Task<User?> GetProfile(int id); // Get user profile by ID
        Task<bool> UserExists(string username); // Check if user exists by username
        Task<User?> GetUserByUsername(string username); // Get user by username
        Task<User?> CreateUser(User userModel);// Register a new user
    }
}
