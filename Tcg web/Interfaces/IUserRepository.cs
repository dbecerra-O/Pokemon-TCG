using Tcg_web.Models;

namespace Tcg_web.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetUsers();
        Task<User?> GetUserById(int id);
        Task<User?> GetUserByName(string name);
        Task<User?> CreateUser(User userModel);

    }
}
