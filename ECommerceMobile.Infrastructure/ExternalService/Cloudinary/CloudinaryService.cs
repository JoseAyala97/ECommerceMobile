using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ECommerceMobile.Application.ExternalService.Cloudinary;
using ECommerceMobile.Application.Models.Cloudinary;
using Microsoft.Extensions.Options;

namespace ECommerceMobile.Infrastructure.ExternalService.CloudinaryService
{
    public class CloudinaryService : ICloudinaryService
    {
        private readonly Cloudinary _cloudinary;

        public CloudinaryService(IOptions<CloudinarySettings> config)
        {
            var cloudinarySettings = config.Value;
            if (cloudinarySettings == null ||
                string.IsNullOrWhiteSpace(cloudinarySettings.CloudName) ||
                string.IsNullOrWhiteSpace(cloudinarySettings.ApiKey) ||
                string.IsNullOrWhiteSpace(cloudinarySettings.ApiSecret))
            {
                throw new ArgumentException("Cloudinary settings are not configured properly.");
            }

            _cloudinary = new Cloudinary(new Account(
                cloudinarySettings.CloudName,
                cloudinarySettings.ApiKey,
                cloudinarySettings.ApiSecret
            ));
        }

        public async Task<string> UploadImageAsync(Stream imageStream, string fileName)
        {
            var uploadParams = new ImageUploadParams()
            {
                File = new FileDescription(fileName, imageStream)
            };

            var uploadResult = await _cloudinary.UploadAsync(uploadParams);

            return uploadResult.SecureUrl.ToString();
        }

        public async Task<bool> DeleteImageAsync(string publicId)
        {
            var deletionParams = new DeletionParams(publicId);
            var deletionResult = await _cloudinary.DestroyAsync(deletionParams);

            return deletionResult.Result == "ok";
        }

        public Task<string> GetImageUrl(string publicId)
        {
            var url = _cloudinary.Api.UrlImgUp.Secure(true).BuildUrl(publicId);
            return Task.FromResult(url);
        }
    }
}
