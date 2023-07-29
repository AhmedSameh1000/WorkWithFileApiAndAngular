using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SocialApi.Helper;
using WorkWithFiles.Api.Models;
using WorkWithFiles.Api.ViewModels;
using ZwajApp.api.Data;
using ZwajApp.api.IRepository;
using ZwajApp.api.Models;
using ZwajApp.api.ViewModels;

namespace ZwajApp.api.RepositoryEmplmentation
{
    public class PhotoCloudinaryRepository : IPhotoCloudinaryRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        private readonly Cloudinary _cloudinary;

        public PhotoCloudinaryRepository(AppDbContext applicationDbContext,
            IOptions<CloudinarySettings> CloudinaryConfig)
        {
            appDbContext = applicationDbContext;
            _cloudinaryConfig = CloudinaryConfig;
            var Account = new Account()
            {
                Cloud = _cloudinaryConfig.Value.CloudName,
                ApiKey = _cloudinaryConfig.Value.ApiKey,
                ApiSecret = _cloudinaryConfig.Value.ApiSecret
            };
            _cloudinary = new Cloudinary(Account);
        }

        public void DeleteImage(string publicId)
        {
            var Image = appDbContext.CloudinaryPhotos.FirstOrDefault(c => c.PublicId == publicId);
            if (Image is null)
                return;
            _cloudinary.DeleteResources(publicId);
            appDbContext.CloudinaryPhotos.Remove(Image);
            appDbContext.SaveChanges();
        }

        public CloudinaryPhoto GetImg(int id)
        {
            var Image = appDbContext.CloudinaryPhotos.Find(id);
            if (Image is null)
                return null!;
            return Image;
        }

        public void UploadImage(PhotoForCreateViewModel photo)
        {
            var File = photo.file;
            var UploadResult = new ImageUploadResult();
            if (File != null && File.Length > 0)
            {
                using var stream = File.OpenReadStream();
                var UploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(File.Name, stream),
                    Transformation = new Transformation()
                    .Width(500).Height(500).Crop("fill").Gravity("face")
                };
                UploadResult = _cloudinary.Upload(UploadParams);
            }
            var PhotoCloudinary = new CloudinaryPhoto()
            {
                Url = UploadResult.Uri.ToString(),
                PublicId = UploadResult.PublicId,
            };
            appDbContext.CloudinaryPhotos.Add(PhotoCloudinary);
            appDbContext.SaveChanges();
        }
    }
}