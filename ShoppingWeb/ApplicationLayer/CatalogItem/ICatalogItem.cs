using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CatalogItem
{
    public interface ICatalogItem
    {
        Task<int> CreateCatalog();
    }
}
