namespace ELearning.Course_Img_Service
{
    public interface IFileUplodeService
    {
        Task<string> UplodeFileAsync(IFormFile formFile);
    }
}
