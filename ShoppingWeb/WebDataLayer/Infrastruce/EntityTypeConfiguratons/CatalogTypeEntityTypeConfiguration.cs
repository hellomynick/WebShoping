using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebDataLayer.Models;

namespace WebDataLayer.Infrastruce.EntityTypeConfiguratons
{
    internal class CatalogTypeEntityTypeConfiguration : IEntityTypeConfiguration<CatalogType>
    {
        public void Configure(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogType");
            builder.HasKey(ct => ct.Id);
            builder.Property(ct => ct.TypeName).IsRequired(true).HasMaxLength(50);
        }
    }
}
