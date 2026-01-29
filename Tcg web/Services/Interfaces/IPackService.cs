using Tcg_web.Dto;

namespace Tcg_web.Services.Interfaces
{
    // Service interface for Pack operations
    public interface IPackService
    {
        Task<OpenPackResponseDto> PurchaseAndOpenPack(string username, int setId); // Method to purchase and open a pack
    }
}
