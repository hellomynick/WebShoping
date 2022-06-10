using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDataLayer.Models;

namespace WebDataLayer.Infrastruce
{
    public static class SeedData
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatalogBrand>().HasData(
            new CatalogBrand()
            {
                Id = 1,
                BrandName = "McDonald's",
            },
            new CatalogBrand()
            {
                Id = 2,
                BrandName = "KFC",
            },
            new CatalogBrand()
            {
                Id = 3,
                BrandName = "PaPaChicken"
            },
            new CatalogBrand()
            {
                Id = 4,
                BrandName = "Merino"
            }
            );

            modelBuilder.Entity<CatalogType>().HasData(
            new CatalogType()
            {
                Id = 1,
                TypeName = "Food",
            },

            new CatalogType()
            {
                Id = 2,
                TypeName = "Drink"
            },
            new CatalogType()
            {
                Id = 3,
                TypeName = "Ice Creame"
            }
            );

            modelBuilder.Entity<CatalogItem>().HasData(
            new CatalogItem()
            {
                Id = 1,
                ProductName = "Combo Chicken KFC",
                Description = "Combo for 2 people",
                Price = 20,
                Discount = 0,
                PriceDiscount = 20,
                MaxStockThreshold = 100,
                CreateOn = DateTime.Now,
                AvailableStock = 100,
                CatalogBrandId = 2,
                CatalogTypeId = 1,
            }
            ) ;
        }
    }
}
