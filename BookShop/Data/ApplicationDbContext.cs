using BookShop.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Product> Produts { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasOne(s => s.ProductDetail)
                .WithOne()
                .HasForeignKey<Product>("DetailsId");

            builder.Entity<Genre>()
                .HasKey(g => g.Id);

            builder.Entity<ProductDetail>()
                .HasOne(det => det.Genre)
                .WithMany()
                .HasForeignKey("GradeId");

            builder.Entity<Order>()
                .HasKey(o => o.Id);

            builder.Entity<Order>()
                .HasOne(o => o.Email)
                .WithMany()
                .HasForeignKey("EmailId");

            builder.Entity<Order>()
                .HasOne(o => o.Address)
                .WithOne()
                .HasForeignKey<Order>("AddressId");

            base.OnModelCreating(builder);
        }
    }
}