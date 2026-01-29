using Tcg_web.Data;
using Tcg_web.Dto;
using Tcg_web.Mappers;
using Tcg_web.Repository.Interfaces;
using Tcg_web.Services.Interfaces;

namespace Tcg_web.Services
{
    // Service for Pack-related business logic
    public class PackService : IPackService
    {
        private readonly ICardRepository _cardRepository;
        private readonly ICollectionRepository _collectionRepository;
        private readonly IUserRepository _userRepository;
        private readonly DataContext _dataContext;

        // Constructor with dependency injection
        public PackService(ICardRepository cardRepository, ICollectionRepository collectionRepository, IUserRepository userRepository, DataContext dataContext)
        {
            _cardRepository = cardRepository;
            _collectionRepository = collectionRepository;
            _userRepository = userRepository;
            _dataContext = dataContext;
        }

        // Purchase and open a pack of cards
        public async Task<OpenPackResponseDto> PurchaseAndOpenPack(string username, int setId)
        {
            // Start a database transaction
            using var transaction = _dataContext.Database.BeginTransaction();

            try
            {
                // Retrieve user information
                var user = await _userRepository.GetUserByUsername(username);
                if (user == null)
                {
                    throw new KeyNotFoundException("User not found");
                }
                // Retrieve set information
                var setInfo = await _cardRepository.GetSet(setId);
                if (setInfo == null)
                {
                    throw new KeyNotFoundException("Set not found");
                }

                // Check if user has sufficient funds
                if (user.Money < setInfo.Price)
                {
                    throw new InvalidOperationException("Insufficient funds");
                }

                // Deduct the pack price from user's balance
                user.Money -= setInfo.Price;

                // Retrieve new cards from the specified set
                var newCards = await _cardRepository.GetCards(5, setId);
                if (!newCards.Any())
                {
                    throw new Exception("No cards available in the specified set.");
                }

                // Add new cards to user's collection
                await _collectionRepository.AddCards(user.Username, newCards);

                // Save changes and commit the transaction
                await _dataContext.SaveChangesAsync();
                await transaction.CommitAsync();

                // Return success response with card details
                return new OpenPackResponseDto
                {
                    success = true,
                    message = "Pack opened successfully",
                    SetId = setId,
                    Cost = setInfo.Price,
                    cards = newCards.Select(c => c.ToCardDto()).ToList()
                };

            }

            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
