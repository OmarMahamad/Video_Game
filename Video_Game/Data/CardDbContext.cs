using Microsoft.EntityFrameworkCore;
using Video_Game.Models;

namespace Video_Game.Data
{
    public class CardDbContext:DbContext
    {
        public CardDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Gamer> Gamers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Games> Games { get; set; }
        public DbSet<Order> Orders { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gamer>()
           .HasOne(g => g.Subscription)
           .WithOne(s => s.Gamer)
           .HasForeignKey<Gamer>(g => g.SubscriptionId);

        }
    }
}
