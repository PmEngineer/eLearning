using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace ELearning.AppNotify_Img_Service
{
    public class FileUpLoadService:IFileUpLoadService
    {
        public IHostingEnvironment hostingEnvironment;
        public FileUpLoadService(IHostingEnvironment hostingEnvironment)
        {
           this.hostingEnvironment = hostingEnvironment;
        }
        public async Task<string> UplodeFileAsync(IFormFile appfile)
        {
            var filepath = Path.Combine(hostingEnvironment.ContentRootPath, @"wwwroot/AppNotify_Img", appfile.FileName);
            using var fileStream = new FileStream(filepath, FileMode.Create);
        await appfile.CopyToAsync(fileStream);
            return filepath;
        }
    }
}
