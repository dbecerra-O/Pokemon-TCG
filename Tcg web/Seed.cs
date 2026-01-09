using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using BCrypt.Net;
using Tcg_web.Data;
using Tcg_web.Models;

namespace Tcg_web
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Collections.Any())
            {
                var cardCollections = new List<Collection>()
                {
                    new Collection()
                    {
                        User = new User()
                        {
                            Username = "Blendy",
                            Email = "blendy@gmail.com",
                            Password = BCrypt.Net.BCrypt.HashPassword("12345678"),
                            Money = 1200,
                            Created_at = DateTime.Now,
                            Updated_at = DateTime.Now
                        },
                        Card = new Card()
                        {
                            Name = "Oddish",
                            ImageUrl = "https://static.tcgcollector.com/content/images/7e/45/db/7e45db400cd293e76f840610594e4ffbdda014f121c1ac3d717c0a9c1cf46859.webp",
                            Type = new Models.Type()
                            {
                                Name = "Grass"
                            },
                            Rarity = new Rarity()
                            {
                                Name = "Common" 
                            }
                        },
                        Quantity = 5,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now
                    },
                    new Collection()
                    {
                        User = new User()
                        {
                            Username = "Bleendingcolor",
                            Email = "blending@gmail.com",
                            Password = BCrypt.Net.BCrypt.HashPassword("12345678"),
                            Money = 500,
                            Created_at = DateTime.Now,
                            Updated_at = DateTime.Now
                        },
                        Card = new Card()
                        {
                            Name = "Mega Charizard X ex",
                            ImageUrl = "https://static.tcgcollector.com/content/images/5c/bd/37/5cbd37e8d9946c64e2a0bbd46fc52e95fc9733b6325572b36019ef1c0f522c49.webp",
                            Type = new Models.Type()
                            {
                                Name = "Fire"
                            },
                            Rarity = new Rarity()
                            {
                                Name = "Double Rare"
                            }
                        },
                        Quantity = 2,
                        Created_at = DateTime.Now,
                        Updated_at = DateTime.Now
                    }
                };
                dataContext.Collections.AddRange(cardCollections);
                dataContext.SaveChanges();
            }
        }
    }
}
