using Tcg_web.Dto.Card;
using Tcg_web.Models;

namespace Tcg_web.Mappers
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
