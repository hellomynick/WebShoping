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
    public class CatalogBrandEntityTypeConfiguration : IEntityTypeConfiguration<CatalogBrand>
    {
        public void Configure(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.ToTable("CatalogBrand");
            builder.HasKey(cb => cb.Id);
            builder.Property(cb => cb.BrandName).IsRequired(true).HasMaxLength(50);
  
            
        }
    }
}
