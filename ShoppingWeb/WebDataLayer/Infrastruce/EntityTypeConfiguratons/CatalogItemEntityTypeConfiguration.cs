using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDataLayer.Models;

namespace WebDataLayer.Infrastruce.EntityTypeConfiguratons
{
    public class CatalogItemEntityTypeConfiguration : IEntityTypeConfiguration<CatalogItem>
    {
        public void Configure(EntityTypeBuilder<CatalogItem> builder)
        {
            builder.ToTable("CatalogItem");
            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.ProductName).IsRequired(true);
            builder.Property(ci => ci.Price).IsRequired(true);
            builder.Property(ci => ci.PriceDiscount).IsRequired(false);
            builder.Property(ci => ci.Discount).IsRequired(false);
            builder.Property(ci => ci.Description).IsRequired(false);
            builder.Property(ci => ci.MaxStockThreshold).IsRequired(false);
            builder.Property(ci => ci.RestockThreshold).IsRequired(false);
            builder.Property(ci => ci.AvailableStock).IsRequired(true);
            builder.Property(ci => ci.CreateOn).IsRequired(true);
            builder.Property(ci => ci.CatalogBrandId).IsRequired(false);
            builder.HasOne(ci => ci.CatalogBrand).WithMany().HasForeignKey(ci => ci.CatalogBrandId);
            builder.Property(ci => ci.CatalogTypeId).IsRequired(false);
            builder.HasOne(ci => ci.CatalogType).WithMany().HasForeignKey(ci => ci.CatalogTypeId);
        }
    }
}
