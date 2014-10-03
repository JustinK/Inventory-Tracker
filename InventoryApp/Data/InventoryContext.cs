using System.Data.Entity;
using InventoryApp.Models;

namespace InventoryApp.Data
{
    public class InventoryContext : DbContext
    {
        public InventoryContext() : base("name=Inventory")
        {
            this.Configuration.LazyLoadingEnabled = true;
            this.Configuration.ProxyCreationEnabled = false;

        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<InventoryItem> InventoryItems { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Tracking> Trackings { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Items)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<InventoryItem>()
                .HasMany(e => e.Trackings)
                .WithRequired(e => e.InventoryItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Item>()
                .HasMany(e => e.InventoryItems)
                .WithRequired(e => e.Item)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Location>()
                .HasMany(e => e.InventoryItems)
                .WithRequired(e => e.Location)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Trackings)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);
        }
    }
}
