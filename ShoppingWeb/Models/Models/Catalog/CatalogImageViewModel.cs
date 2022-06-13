using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models.Catalog
{
    public class CatalogImageViewModel
    {
        public int Id { get; set; }
        public string Caption { get; set; }
        public bool IsDefault { get; set; }
        public int SortOrder { get; set; }
        public int CatalogItemId { get; set; }
        public DateTime CreateOn { get; set; }
        public IFormFile IFormFile { get; set; }
    }
}
