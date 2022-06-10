using ApplicationLayer.StorageService;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDataLayer.Infrastruce;
using WebDataLayer.Models;

namespace ApplicationLayer.CatalogItemServices
{
    public class CatalogItemServices : ICatalogItemServices
    {
        private readonly CatalogContext _contet;
        private readonly IStorageService storageService;
        public CatalogItemServices(CatalogContext catalogContext)
        {
            _catalogContent = catalogContext;
        }
        public async Task<int> CreateCatalogItem(CatalogItemViewModel createCatalogItem)
        {
            var catalogItem = new CatalogItem()
            {
                ProductName = createCatalogItem.ProductName,
                Description = createCatalogItem.Description,
                Price = createCatalogItem.Price,
                AvailableStock = createCatalogItem.AvailableStock,
                CatalogBrandId = createCatalogItem.CatalogBrandId,
                CatalogTypeId = createCatalogItem.CatalogTypeId,
                CreateOn = DateTime.Now,
                UpdateOn = DateTime.Now,
            };
            _catalogContent.Add(catalogItem);
            await _catalogContent.SaveChangesAsync();
            return catalogItem.Id;
        }

        public async Task<int> DeleteCatalogItem(int id)
        {
            var catalogItem = _catalogContent.CatalogItems.FindAsync(id);
            await _catalogContent.CatalogItems.Remove(catalogItem);
        }

        public Task<int> UpdateCatalogItem(CatalogItemViewModel updateCatalogItem)
        {
            throw new NotImplementedException();
        }
    }
}
