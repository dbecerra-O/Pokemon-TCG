using TcgWeb.Models.Dtos.Card;

namespace TcgWeb.Models.Dtos
{
    public class GetPackagesDto
    {
        public int SetPrice { get; set; }
        public List<PackageDto> Packages { get; set; } = [];
    }
}
