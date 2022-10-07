using Microsoft.EntityFrameworkCore;
using ProductsWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductsWebAPI.DbContexts
{
    public class ProductLibraryContext : DbContext
    {
        public ProductLibraryContext(DbContextOptions<ProductLibraryContext> options)
           : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    ID = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                    Name = "Battery",
                    Price = 90,
                    Quantity = 120,
                    CateogryID = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                    ImgURL = ""
                },
                new Product()
                {
                    ID = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                    Name = "Screen",
                    Price = 150,
                    Quantity = 80,
                    CateogryID = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                    ImgURL = ""
                },
                new Product()
                {
                    ID = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                    Name = "Headphones",
                    Price = 60,
                    Quantity = 200,
                    CateogryID = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                    ImgURL = ""
                }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    ID = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                    Name = "Electronics"
                },
                new Category()
                {
                    ID = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                    Name = "Accessories"
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
