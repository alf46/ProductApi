using Microsoft.EntityFrameworkCore;
using ProductApi.Entities;
using System;

namespace ProductApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .ToTable(nameof(Product));

            modelBuilder.Entity<Product>()
                .Property(x => x.Description)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Product>()
                .Property(x => x.Price)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Product>()
                .Property(x => x.CreateDate)
                .HasDefaultValueSql("getdate()")
                .IsRequired();

            modelBuilder.Entity<Product>()
                .HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryId)
                .HasConstraintName("FK_Cat_Prod");
        }
    }
}