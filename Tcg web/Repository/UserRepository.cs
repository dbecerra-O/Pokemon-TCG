using Microsoft.EntityFrameworkCore;
using Tcg_web.Data;
using Tcg_web.Models;
using Tcg_web.Repository.Interfaces;

namespace Tcg_web.Repository
{
    // Repository for User entity
    public class UserRepository(DataContext context) : IUserRepository
    {
        private readonly DataContext _context = context;

        // Get all users
        public async Task<List<User>> GetUsers()
        {
            return await _context.Users.OrderBy(p => p.Id).ToListAsync();
        }

        // Get user profile by ID
        public async Task<User?> GetProfile(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(i => i.Id == id);
        }

        // Check if user exists by username
        public async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(u => u.Username == username);
        }

        // Get user by username
        public async Task<User?> GetUserByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
        }

        // Create a new user
        public async Task<User?> CreateUser(User userModel)
        {
            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }
    }
}
