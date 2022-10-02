using AutoDockTestApp.Extension;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AutoDockTestApp.Util
{
    public class AttachmentManager : IAttachmentManager
    {
        private readonly IWebHostEnvironment _webEnvironment;
        private const string _filesFolder = "Files";

        public AttachmentManager(IWebHostEnvironment environment)
        {
            _webEnvironment = environment;
        }

        public async Task<string> SaveAttachmentAsync(IFormFile fileData)
        {
            var filePath = GetFilePath(fileData.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await fileData.CopyToAsync(fileStream);
            }
            return filePath;
        }

        public async Task DeleteAttachmentAsync(string fileName)
        {
            var filePath = GetFilePath(fileName);
            if (File.Exists(filePath))
            {
                var fileInfo = new FileInfo(filePath);
                await fileInfo.DeleteAsync();
            }
        }

        private string GetFilePath(string fileShortName)
        {
            string uploads = Path.Combine(_webEnvironment.ContentRootPath, _filesFolder);
            return Path.Combine(uploads, fileShortName);
        }
    }
}
