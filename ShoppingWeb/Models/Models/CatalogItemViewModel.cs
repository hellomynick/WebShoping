using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class CatalogItemViewModel
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
        public int? CatalogBrandId { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }
    }
}
