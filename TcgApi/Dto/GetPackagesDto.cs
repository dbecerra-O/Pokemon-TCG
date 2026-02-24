using TcgApi.Dto.Card;

namespace TcgApi.Dto
{
    public class GetPackagesDto
    {
        public int SetPrice { get; set; }
        public List<PackageDto> Packages { get; set; } = [];
    }
}
