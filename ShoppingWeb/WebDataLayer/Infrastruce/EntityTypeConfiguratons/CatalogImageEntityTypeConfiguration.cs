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
    public class CatalogImageEntityTypeConfiguration : IEntityTypeConfiguration<CatalogImage>
    {
        public void Configure(EntityTypeBuilder<CatalogImage> builder)
        {
            builder.ToTable("CatalogImage");
            builder.HasKey(ci => ci.Id);
            builder.Property(ci => ci.ImageName).IsRequired(true);
            builder.Property(ci => ci.ImageUri).IsRequired(true);
            builder.Property(ci => ci.FileSize).IsRequired(true);
            builder.Property(ci => ci.DateCreate).IsRequired(false);
            builder.Property(ci => ci.IsDefault).IsRequired(false);
            builder.Property(ci => ci.SortOrder).IsRequired(false);
            builder.Property(ci => ci.CatalogItemId).IsRequired(false);
            builder.HasOne(ci => ci.CatalogItem).WithMany().HasForeignKey(ci => ci.CatalogItem);
        }
    }
}
