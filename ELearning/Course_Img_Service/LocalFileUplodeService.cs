using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace ELearning.Course_Img_Service
{
    public class LocalFileUplodeService : IFileUplodeService
    {
        public IHostingEnvironment hostingEnvironment;
        public LocalFileUplodeService(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> UplodeFileAsync(IFormFile formFile)
        {
            var filePath = Path.Combine(hostingEnvironment.ContentRootPath, @"wwwroot/Course_Img", formFile.FileName);
               using var fileStream = new FileStream(filePath, FileMode.Create);
               await formFile.CopyToAsync(fileStream);
               return filePath;
        }
    }
}
