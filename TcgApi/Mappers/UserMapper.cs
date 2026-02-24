using TcgApi.Dto;
using TcgApi.Models;

namespace TcgApi.Mappers
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
