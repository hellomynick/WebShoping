namespace WebDataLayer.Models
{
    public class CatalogItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal? PriceDiscount { get; set; }
        public string Description { get; set; }
        public decimal? Discount { get; set; }
        public int? MaxStockThreshold { get; set; }
        public int AvailableStock { get; set; }
        public int? RestockThreshold { get; set; }
        public int? CatalogTypeId { get; set; }
        public CatalogType CatalogType { get; set; }
        public int? CatalogBrandId { get; set; }
        public CatalogBrand CatalogBrand { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }
    }
}