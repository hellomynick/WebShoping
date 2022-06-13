using ApplicationLayer.StorageService;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models.Models.Catalog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using WebDataLayer.Infrastruce;
using WebDataLayer.Models;

namespace ApplicationLayer.CatalogItemServices
{
    public class CatalogItemServices : ICatalogItemServices
    {
        private readonly CatalogContext _context;
        private readonly IStorageService _storageService;
        private const string CONTENT_FOLDER = "content-folder";
        public CatalogItemServices(CatalogContext catalogContext, IStorageService storageService)
        {
            _context = catalogContext;
            _storageService = storageService;
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
            _context.Add(catalogItem);
            await _context.SaveChangesAsync();
            return catalogItem.Id;
        }

        public async Task<int> DeleteCatalogItem(int id)
        {
            var catalogItem = await _context.CatalogItems.FindAsync(id);
            var image = _context.CatalogImages.Where(ci => ci.CatalogItemId == id);
            foreach(var img in image)
            {
                await _storageService.DeleteFileAsync(img.ImageUri);
            }
            _context.CatalogItems.Remove(catalogItem);
            return await _context.SaveChangesAsync();

        }

        public async Task<int> UpdateCatalogItem(CatalogItemViewModel updateCatalogItem)
        {
            var catalog = await _context.CatalogItems.FirstOrDefaultAsync(c => c.Id == updateCatalogItem.Id);
            catalog.ProductName = catalog.ProductName;
            catalog.Price = updateCatalogItem.Price;
            catalog.PriceDiscount = updateCatalogItem.PriceDiscount;
            catalog.Description = updateCatalogItem.Description;
            catalog.CatalogBrandId = updateCatalogItem.CatalogBrandId;
            catalog.CatalogTypeId = updateCatalogItem.CatalogTypeId;
            catalog.AvailableStock = updateCatalogItem.AvailableStock;
            catalog.UpdateOn = DateTime.Now;
            return await _context.SaveChangesAsync();
           
        }
        public async Task<int> AddImage(CatalogImageViewModel catalogImage)
        {
            var image = new CatalogImage()
            {
                ImageName = catalogImage.Caption,
                IsDefault = catalogImage.IsDefault,
                CatalogItemId = catalogImage.CatalogItemId,
                DateCreate = catalogImage.CreateOn
            };
            if(catalogImage.IFormFile != null)
            {
                image.ImageUri = await SaveFile(catalogImage.IFormFile);
                image.FileSize =  catalogImage.IFormFile.Length;    
            }
            _context.CatalogImages.Add(image);
            await _context.SaveChangesAsync();
            return catalogImage.Id;
        }

        public async Task<int> UpdateImage (CatalogImageViewModel catalogImage)
        {
            var image = await _context.CatalogImages.FindAsync(catalogImage.Id);
            image.ImageUri = await SaveFile(catalogImage.IFormFile);
            image.FileSize = catalogImage.IFormFile.Length;
            _context.CatalogImages.Update(image);
            return await _context.SaveChangesAsync();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + CONTENT_FOLDER + "/" + fileName;
        }

    }
}
