using Tcg_web.Dto;
using Tcg_web.Models;

namespace Tcg_web.Mappers
{
    // Mapper for User model to UserDto
    public static class UserMapper
    {
        // Convert User model to UserDto
        public static UserDto ToUserDto (this User user)
        {
            // Map properties from User to UserDto
            return new UserDto
            {
                Id = user.Id,
                Username = user.Username,
                Money = user.Money,
            };
        }

    }
}
