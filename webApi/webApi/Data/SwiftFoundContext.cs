using Microsoft.EntityFrameworkCore;
using webApi.DataSeed;
using webApi.Models;

namespace webApi.Data
{
    public class SwiftFoundContext : DbContext
    {
        public SwiftFoundContext(DbContextOptions<SwiftFoundContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<ItemLocation> ItemLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemLocation>()
                .HasOne(il => il.Item)
                .WithMany()
                .HasForeignKey(il => il.ItemId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Seed();
        }
    }
}
