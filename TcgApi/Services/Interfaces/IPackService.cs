using TcgApi.Dto;

namespace TcgApi.Services.Interfaces
{
    // Service interface for Pack operations
    public interface IPackService
    {
        Task<OpenPackResponseDto> PurchaseAndOpenPack(string username, int setId); // Method to purchase and open a pack
        Task<GetPackagesDto> PackagesDetails(int setId); // Method to get set details and their packages
    }
}
