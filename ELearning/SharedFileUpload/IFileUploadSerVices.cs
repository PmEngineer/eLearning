namespace ELearning.SharedFileUpload
{
    public interface IFileUploadSerVices
    {
        Task<string> UplodeFileAsync(IFormFile uploadFile,string targetFolder);
    }
}
