using Microsoft.EntityFrameworkCore;
using Tcg_web.Data;
using Tcg_web.Interfaces;
using Tcg_web.Models;

namespace Tcg_web.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetUsers()
        {
            return _context.Users.OrderBy(p => p.Id).ToList();
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<User?> CreateUser(User userModel)
        {
            _context.Users.Add(userModel);
            await _context.SaveChangesAsync();
            return userModel;
        }

        public async Task<User?> GetUserByName(string name)
        {
            return await _context.Users.FirstOrDefaultAsync(i => i.Username == name);
        }
    }
}
