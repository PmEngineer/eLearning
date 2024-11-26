using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting.Internal;
using System;
using IHostingEnvironment = Microsoft.Extensions.Hosting.IHostingEnvironment;
namespace ELearning.SharedFileUpload
{
    public class FileUploadServices : IFileUploadSerVices
    {
        public IHostingEnvironment hostingEnvironment;
        private readonly Dictionary<string, string> _fileTypeFolders = new Dictionary<string, string>
        {
            { ".jpg", "Images" },
            { ".jpeg", "Images" },
            { ".png", "Images" },
            { ".gif", "Images" },
            { ".mp4", "Videos" },
            { ".avi", "Videos" },
            { ".pdf", "Documents" },
            { ".mp3", "Audio" },
            { ".wav", "Audio" }
        };
        public FileUploadServices(IHostingEnvironment hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
        }

        public async Task<string> UplodeFileAsync(IFormFile uploadFile, string targetFolder)
        {
            if (uploadFile == null || uploadFile.Length == 0)
            {
                throw new Exception("File is not selected.");
            }


            var extension = Path.GetExtension(uploadFile.FileName).ToLowerInvariant();
            if (!_fileTypeFolders.ContainsKey(extension))
            {
                throw new InvalidDataException("Unsupported file type.");
            }


            var folderName = Path.Combine(targetFolder, _fileTypeFolders[extension]);
            var fullPath = Path.Combine(hostingEnvironment.ContentRootPath, "wwwroot", folderName);
            Directory.CreateDirectory(fullPath); 

         
            var filePath = Path.Combine(fullPath, uploadFile.FileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await uploadFile.CopyToAsync(stream);
            }

            return filePath; 
        }
    }
}
