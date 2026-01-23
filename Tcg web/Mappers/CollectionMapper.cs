using Tcg_web.Dto;
using Tcg_web.Models;

namespace Tcg_web.Mappers
{
    // Mapper class for Collection entity to CollectionDto
    public static class CollectionMapper
    {
        // Converts a Collection entity to a CollectionDto
        public static CollectionDto ToCollectionDto(this Collection collection)
        {
            // Map properties from Collection to CollectionDto
            return new CollectionDto
            {
                Id = collection.Id,
                Quantity = collection.Quantity,
                ObtainetAt = collection.Created_at,
                Card = collection.Card.ToCardDto()
            };
        }
    }
}
