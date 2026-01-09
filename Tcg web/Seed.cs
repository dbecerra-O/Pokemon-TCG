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

                        }

                    }
                };
            }
        }
    }
}
