namespace ECommerceMobile.Application.ExternalService.Cloudinary
{
    public interface ICloudinaryService
    {
        Task<string> UploadImageAsync(Stream imageStream, string fileName);
        Task<bool> DeleteImageAsync(string publicId);
        Task<string> GetImageUrl(string publicId);
    }
}
