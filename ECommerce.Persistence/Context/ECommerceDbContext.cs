using ECommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Persistence.Context
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                            new Category { Id = 1, Name = "Elektronik" },
                            new Category { Id = 2, Name = "Giyim" },
                            new Category { Id = 3, Name = "Ev ve Yaşam" });

            modelBuilder.Entity<Product>().HasData(
                            new Product { Id = 1, Name = "Akıllı Telefon", Price = 999.99m, Stock = 50, CategoryId = 1 },
                            new Product { Id = 2, Name = "Laptop", Price = 1999.99m, Stock = 30, CategoryId = 1 },
                            new Product { Id = 3, Name = "Kulaklık", Price = 199.99m, Stock = 100, CategoryId = 1 },
                            new Product { Id = 4, Name = "Televizyon", Price = 2999.99m, Stock = 20, CategoryId = 1 },
                            new Product { Id = 5, Name = "Tablet", Price = 799.99m, Stock = 40, CategoryId = 1 },

                            new Product { Id = 6, Name = "Tişört", Price = 49.99m, Stock = 150, CategoryId = 2 },
                            new Product { Id = 7, Name = "Pantolon", Price = 89.99m, Stock = 80, CategoryId = 2 },
                            new Product { Id = 8, Name = "Mont", Price = 199.99m, Stock = 60, CategoryId = 2 },
                            new Product { Id = 9, Name = "Ayakkabı", Price = 149.99m, Stock = 70, CategoryId = 2 },
                            new Product { Id = 10, Name = "Kışlık Bot", Price = 249.99m, Stock = 50, CategoryId = 2 },

                            new Product { Id = 11, Name = "Masa", Price = 299.99m, Stock = 20, CategoryId = 3 },
                            new Product { Id = 12, Name = "Sandalye", Price = 149.99m, Stock = 40, CategoryId = 3 },
                            new Product { Id = 13, Name = "Lamba", Price = 59.99m, Stock = 80, CategoryId = 3 },
                            new Product { Id = 14, Name = "Perde", Price = 79.99m, Stock = 30, CategoryId = 3 },
                            new Product { Id = 15, Name = "Vazo", Price = 29.99m, Stock = 100, CategoryId = 3 });

            modelBuilder.Entity<Product>()
                        .HasOne(p => p.Category)
                        .WithMany(c => c.Products)
                        .HasForeignKey(p => p.CategoryId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
