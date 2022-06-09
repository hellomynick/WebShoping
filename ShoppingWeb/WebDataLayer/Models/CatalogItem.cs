using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDataLayer.Models
{
    public class CatalogItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public decimal PriceDiscount { get; set; }
        public string Description { get; set; }
        public string PictureName { get; set; }
        public string PictureUri { get; set; }
        public decimal Discount { get; set; }
        public int Stock { get; set; }
        public int MaxStock { get; set; }
        public int CatalogTypeId { get; set; }
        public CatalogType CatalogType { get; set; }
        public int CatalogBrandId { get; set; }
        public CatalogBrand CatalogBrand { get; set; }
        public DateTime CreateOn { get; set; }
        public DateTime UpdateOn { get; set; }


    }
}
