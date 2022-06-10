using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using WebDataLayer.Infrastruce.EntityTypeConfiguratons;
using WebDataLayer.Models;

namespace WebDataLayer.Infrastruce
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CatalogBrandEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogItemEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());

            //SeedData
            builder.Seed();
        }
        public DbSet<CatalogBrand> CatalogBrands { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }
        public DbSet<CatalogImage> CatalogImages { get; set; }
    }

    public class ShoppingWebFactory : IDesignTimeDbContextFactory<CatalogContext>
    {
        public CatalogContext CreateDbContext(string[] args)
        {
            var OptionBuilder = new DbContextOptionsBuilder<CatalogContext>()
                .UseSqlServer("Server=.;Initial Catalog=Webshoping.CatalogDb;Integrated Security=true");
            return new CatalogContext(OptionBuilder.Options);
        }
    }
}