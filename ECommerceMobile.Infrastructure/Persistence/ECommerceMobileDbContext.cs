using ECommerceMobile.Domain.Common;
using ECommerceMobile.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceMobile.Infrastructure.Persistence
{
    public class ECommerceMobileDbContext : DbContext
    {
        public ECommerceMobileDbContext(DbContextOptions<ECommerceMobileDbContext> options) : base(options)
        {
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach(var entry in ChangeTracker.Entries<BaseDomainModel>())
            {
                switch(entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedDate = DateTime.UtcNow;
                        entry.Entity.CreatedBy = "system";
                        break;

                    case EntityState.Modified:
                        entry.Entity.LastModifiedDate = DateTime.UtcNow;
                        entry.Entity.LastModifiedBy = "system";
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Total);
                entity.HasMany(c => c.Items)
                      .WithOne(ci => ci.Cart)
                      .HasForeignKey(ci => ci.CartId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(ci => ci.Id); 
                entity.HasOne(ci => ci.Product)
                      .WithMany() 
                      .HasForeignKey(ci => ci.ProductId)
                      .OnDelete(DeleteBehavior.Restrict); 
            });
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(p => p.Id);
                entity.Property(p => p.Price);
            });
            modelBuilder.Entity<Wishlist>(entity =>
            {
                entity.HasKey(w => w.Id);
                entity.HasMany(w => w.WishlistProducts)
                      .WithOne(wp => wp.Wishlist)
                      .HasForeignKey(wp => wp.WishlistId)
                      .OnDelete(DeleteBehavior.Cascade);
            });
            modelBuilder.Entity<WishlistProduct>(entity =>
            {
                //llave compuesta para la tabla intermedia
                entity.HasKey(wp => new { wp.WishlistId, wp.ProductId });
                entity.HasOne(wp => wp.Wishlist)
                      .WithMany(w => w.WishlistProducts)
                      .HasForeignKey(wp => wp.WishlistId)
                      .OnDelete(DeleteBehavior.Cascade);
                entity.HasOne(wp => wp.Product)
                      .WithMany() 
                      .HasForeignKey(wp => wp.ProductId)
                      .OnDelete(DeleteBehavior.Restrict);
            });
        }
        public DbSet<Cart>? Carts { get; set; }
        public DbSet<CartItem>? CartItems { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistProduct>? WishlistProducts { get; set; }
    }
}
