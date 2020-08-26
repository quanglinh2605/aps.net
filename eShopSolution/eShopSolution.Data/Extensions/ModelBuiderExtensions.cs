using eShopSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Extensions
{
    public static class ModelBuiderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTitle", Value = "This is home page of eShopSolution" },
                new AppConfig() { Key = "HomeKeyword", Value = "This is keyword of eShopSolution" },
                new AppConfig() { Key = "HomeDescription", Value = "This is description of eShopSolution" });

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi-VN", Name = "Vietnamese", IsDefault = true },
                new Language() { Id = "en-US", Name = "English", IsDefault = false });

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Enums.Status.Active
                },
                new Category()
                {
                    Id = 2,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 2,
                    Status = Enums.Status.Active
                });

            modelBuilder.Entity<CategoryTranslation>().HasData(
                 new CategoryTranslation() { Id = 1, CategoryId = 2 ,Name = "Ao nu", LanguageId = "vi-VN", SeoAlias = "ao-nu", SeoDescription = "San pham ao thoi trang nu", SeoTitle = "San pham ao thoi trang nu" },
                 new CategoryTranslation() { Id = 2, CategoryId = 2 ,Name = "Women Shirt", LanguageId = "en-US", SeoAlias = "women-shirt", SeoDescription = "The shirt product for women", SeoTitle = "The shirt product for women" },
                 new CategoryTranslation() { Id = 3, CategoryId = 1 ,Name = "Ao nam", LanguageId = "vi-VN", SeoAlias = "ao-nam", SeoDescription = "San pham ao thoi trang nam", SeoTitle = "San pham ao thoi trang nam" },
                 new CategoryTranslation() { Id = 4, CategoryId = 1 ,Name = "Men Shirt", LanguageId = "en-US", SeoAlias = "men-shirt", SeoDescription = "The shirt product for men", SeoTitle = "The shirt product for men" }
                );

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    OriginalPrice = 100000,
                    Price = 200000,
                    Stock = 0,
                    ViewCount = 0,
                });

            modelBuilder.Entity<ProductTranslation>().HasData(
                 new ProductTranslation()
                 {
                     Id = 1,
                     ProductId = 1,
                     Name = "Ao so mi nam trang Viet Tien",
                     LanguageId = "vi-VN",
                     SeoAlias = "ao-so-mi-nam-trang-viet-tien",
                     SeoDescription = "Ao so mi nam trang Viet Tien",
                     SeoTitle = "Ao so mi nam trang Viet Tien",
                     Details = "Ao so mi nam trang Viet Tien",
                     Description = "Ao so mi nam trang Viet Tien"
                 },
                new ProductTranslation()
                {
                    Id = 2,
                    ProductId = 1,
                    Name = "Viet Tien Men T-Shirt",
                    LanguageId = "en-US",
                    SeoAlias = "viet-tien-men-t-shirt",
                    SeoDescription = "Viet Tien Men T-Shirt",
                    SeoTitle = "Viet Tien Men T-Shirt",
                    Details = "Viet Tien Men T-Shirt",
                    Description = "Viet Tien Men T-Shirt"
                });

            modelBuilder.Entity<ProductInCategory>().HasData(
                new ProductInCategory() { ProductId = 1, CategoryId = 1 }
                );

        }
    }
}
