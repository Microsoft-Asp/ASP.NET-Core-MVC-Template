using Constants.Enums;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Linq;

namespace Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<ApplicationRole> AppRoles { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductCategory> ProductCategories { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Seed all categories from the enum
            var productCategoriesArray = (CategoriesEnum[]) Enum.GetValues(typeof(CategoriesEnum));
            var productCategories = productCategoriesArray.Select(categoryEnum => new ProductCategory
            {
                CategoryId = (int) categoryEnum,
                Name = categoryEnum.ToString()
            });

            builder.Entity<ProductCategory>().HasData(productCategories);

            builder.Entity<Product>().HasData(
                new Product{
                    ProductId = 1,
                    Name = "Apple",
                    Price = 0.50m,
                    ProductCategoryId = (int) CategoriesEnum.Food
                },
                new Product
                {
                    ProductId = 2,
                    Name = "Coca Cola",
                    Price = 1.50m,
                    ProductCategoryId = (int)CategoriesEnum.Drinks
                },
                new Product
                {
                    ProductId = 3,
                    Name = "Ketchup",
                    Price = 0.20m,
                    ProductCategoryId = (int)CategoriesEnum.Condiments
                },
                new Product
                {
                    ProductId = 4,
                    Name = "Pepper",
                    Price = 0.10m,
                    ProductCategoryId = (int)CategoriesEnum.Spices
                }
            );

            base.OnModelCreating(builder);
        }
    }
}