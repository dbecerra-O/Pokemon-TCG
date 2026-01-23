using Microsoft.EntityFrameworkCore;
using Tcg_web.Models;
namespace Tcg_web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        // Definicion de los DbSet para cada entidad
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Set> Sets { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Rarity> Rarities { get; set; }
        public DbSet<Models.Type> Types { get; set; }
        public DbSet<EnergyType> EnergyTypes { get; set; }
        public DbSet<Collection> Collections { get; set; }
    }
}
