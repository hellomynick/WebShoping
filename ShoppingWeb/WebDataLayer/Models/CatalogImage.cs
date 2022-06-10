using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebDataLayer.Models
{
    public class CatalogImage
    {
        public int Id { get; set; }
        public string ImageName { get; set; }
        public string ImageUri { get; set; }
        public bool IsDefault { get; set; }
        public DateTime DateCreate { get; set; }
        public int SortOrder { get; set; }
        public long FileSize { get; set; }
        public int CatalogItemId { get; set; }
        public CatalogItem CatalogItem { get; set; }
    }
}
