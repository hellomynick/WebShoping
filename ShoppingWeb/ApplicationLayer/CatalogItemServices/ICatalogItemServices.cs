using Models.Models.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.CatalogItemServices
{
    public interface ICatalogItemServices
    {
        Task<int> CreateCatalogItem(CatalogItemViewModel createCatalogItem);
        Task<int> UpdateCatalogItem(CatalogItemViewModel updateCatalogItem);
        Task<int> DeleteCatalogItem(int id);

    }
}
