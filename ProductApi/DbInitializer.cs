using ProductApi.Data;
using ProductApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductApi
{
    public static class DbInitializer
    {
        public static void Initialize(AppDbContext context)
        {
            if (context.Database.EnsureCreated())
            {
                var category = new Category { Name = "Alimentos Básicos" };

                context.Products.AddRange(
                        new Product
                        {
                            Description = "Arroz La Garza",
                            Price = 26.95,
                            Category = category,
                        },
                        new Product
                        {
                            Description = "Huevo, Carton",
                            Price = 102.95,
                            Category = category,
                        });

                context.SaveChanges();
            }
        }
    }
}