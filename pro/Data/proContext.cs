using pro.Models;
using Microsoft.EntityFrameworkCore;

namespace pro.Data
{
    public class proContext :DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Distributor> Distributor { get; set; }
        public proContext(DbContextOptions<proContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //m-m
            modelBuilder.Entity<Order>().HasKey(o => new { o.userId, o.itemId });
            //1-m for m-m
            modelBuilder.Entity<Order>()
                       .HasOne(o => o.user)
                       .WithMany(u => u.orders)
                       .HasForeignKey(o => o.userId);

            modelBuilder.Entity<Order>()
                        .HasOne(o => o.item)
                        .WithMany(i => i.orders)
                        .HasForeignKey(o => o.itemId);

            //1-m
            modelBuilder.Entity<Distributor>()
                        .HasMany(d => d.items)
                        .WithOne(i => i.distributor);

            //1-1
            modelBuilder.Entity<User>()
               .HasOne(u => u.review)
               .WithOne(r => r.user)
               .HasForeignKey<Review>(r => r.userId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
