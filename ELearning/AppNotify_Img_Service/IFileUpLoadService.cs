namespace ELearning.AppNotify_Img_Service
{
    public interface IFileUpLoadService
    {
        Task<string> UplodeFileAsync(IFormFile appFile);
    }
}
