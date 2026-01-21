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
        public DbSet<Collection> Collections { get; set; }
        public DbSet<Content> Contents { get; set; } // Relacion de muchos a muchos

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuracion de la relacion muchos a muchos entre Set y Card a traves de Content
            modelBuilder.Entity<Content>()
                .HasKey(pc => new { pc.SetId, pc.CardId });
            modelBuilder.Entity<Content>()
                .HasOne(p => p.Set)
                .WithMany(pc => pc.Contents)
                .HasForeignKey(p => p.SetId);
            modelBuilder.Entity<Content>()
                .HasOne(c => c.Card)
                .WithMany(pc => pc.Contents)
                .HasForeignKey(c => c.CardId);
        }
    }
}
