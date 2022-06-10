using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.StorageService
{
    public class StorageServices : IStorageService
    {
        private readonly string _contentFolder;
        private const string CONTENT_FOLDER = "content-folder";
        public StorageServices(IWebHostEnvironment webHostEnvironment)
        {
            _contentFolder = Path.Combine(webHostEnvironment.WebRootPath, CONTENT_FOLDER);
        }
        public async Task DeleteFileAsync(string fileName)
        {
            var filePath = Path.Combine(_contentFolder, fileName);
            if(File.Exists(filePath))
            {
                await Task.Run(() => File.Delete(filePath));
            }
        }

        public string GetFileUrl(string fileName)
        {
            return $"/{CONTENT_FOLDER}/{fileName}";
        }

        public async Task SaveFileAsync(Stream mediaBinaryStream, string fileName)
        {
            var filePath = Path.Combine(_contentFolder, fileName);
            using var output = new FileStream(filePath, FileMode.Create);
            await mediaBinaryStream.CopyToAsync(output);
        }
    }
}
