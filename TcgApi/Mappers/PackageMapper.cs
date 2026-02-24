using TcgApi.Dto.Card;
using TcgApi.Models;

namespace TcgApi.Mappers
{
    public static class PackageMapper
    {
        public static PackageDto ToPackageDto(this Package package)
        {
            return new PackageDto
            {
                Id = package.Id,
                Name = package.Name,
                ImageUrl = package.ImageUrl,
            };
        }
    }
}
