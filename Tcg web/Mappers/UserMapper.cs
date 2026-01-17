using Tcg_web.Dto;
using Tcg_web.Models;

namespace Tcg_web.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToUserDto (this User user)
        {
            return new UserDto
            {
                Id = user.Id,
                UserName = user.Username,
                Email = user.Email,
                Money = user.Money,
                Created_at = user.Created_at,
                Updated_at = user.Updated_at
            };
        }
    }
}
