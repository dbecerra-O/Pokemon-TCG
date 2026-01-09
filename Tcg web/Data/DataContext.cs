using Microsoft.EntityFrameworkCore;
using Tcg_web.Models;
namespace Tcg_web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Collection> Collections { get; set; } // Relacion de muchos a muchos

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Collection>()
                .HasKey(pc => new { pc.UserId, pc.CardId });
            modelBuilder.Entity<Collection>()
                .HasOne(p => p.User)
                .WithMany(pc => pc.Collections)
                .HasForeignKey(p => p.UserId);
            modelBuilder.Entity<Collection>()
                .HasOne(c => c.Card)
                .WithMany(pc => pc.Collections)
                .HasForeignKey(c => c.CardId);
        }
    }
}
