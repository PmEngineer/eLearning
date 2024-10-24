namespace ELearning.Post_Img_Service
{
    public interface IFileUploadSerVice
    {
        Task<string> UplodeFileAsync(IFormFile postFile);
    }
}
