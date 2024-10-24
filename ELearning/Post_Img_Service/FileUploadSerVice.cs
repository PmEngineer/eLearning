using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;

namespace ELearning.Post_Img_Service
{
    public class FileUploadSerVice :IFileUploadSerVice
    {
        public IHostingEnvironment hostingEnvironment;
        public FileUploadSerVice(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }
        public async Task<string>UplodeFileAsync(IFormFile postfile)
        {
            var filepath = Path.Combine(hostingEnvironment.ContentRootPath, @"wwwroot/Post_Img", postfile.FileName);
            using var fileStream = new FileStream(filepath, FileMode.Create);
            await postfile.CopyToAsync(fileStream);
            return filepath;    
        }

    }
}
