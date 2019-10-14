using Microsoft.EntityFrameworkCore;
using ProductApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
             .HasColumnType("decimal");

            modelBuilder.Entity<Product>()
                .HasData(
                    new Product
                    {
                        Id = 1,
                        Description = "Arroz La Garza",
                        CreateDate = DateTime.Now,
                        Price = 26.95
                    },
                    new Product
                    {
                        Id = 2,
                        Description = "Huevo, Carton",
                        CreateDate = DateTime.Now,
                        Price = 102.95
                    }
                );
        }
    }
}