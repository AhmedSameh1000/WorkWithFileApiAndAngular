using Microsoft.EntityFrameworkCore;
using NuGet.Packaging.Signing;
using ZwajApp.api.Data;
using ZwajApp.api.IRepository;
using ZwajApp.api.Models;
using ZwajApp.api.ViewModels;

namespace ZwajApp.api.RepositoryEmplmentation
{
    public class PhotoRepository : IPhotoRepository
    {
        private readonly AppDbContext appDbContext;
        private readonly IWebHostEnvironment _host;
        private readonly HttpContext _httpContext;

        public PhotoRepository(AppDbContext applicationDbContext, IWebHostEnvironment host, IHttpContextAccessor httpContextAccessor)
        {
            appDbContext = applicationDbContext;
            _host = host;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public void DeleteImage(int id)
        {
            var Img = appDbContext.Photos.FirstOrDefault(f => f.Id == id);
            if (Img is null)
                return;

            string RootPath = _host.WebRootPath.Replace("\\\\", "\\");
            var imageNameToDelete = System.IO.Path.GetFileNameWithoutExtension(Img.Url);
            var EXT = Path.GetExtension(Img.Url);
            var oldImagePath = $@"{RootPath}\images\{imageNameToDelete}{EXT}";
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            appDbContext.Remove(Img);
            appDbContext.SaveChanges();
        }

        public void UploadImage(PhotoForDetailsDto photo)
        {
            string RootPath = _host.WebRootPath;
            var ImageUrl = "";
            string fileName = Guid.NewGuid().ToString();
            string imageFolderPath = Path.Combine(RootPath, @"images");
            string extension = Path.GetExtension(photo.Img.FileName);
            using (FileStream fileStreams = new(Path.Combine(imageFolderPath,
                               fileName + extension), FileMode.Create))
            {
                photo.Img.CopyTo(fileStreams);
            }
            ImageUrl = @$"{_httpContext.Request.Scheme}://{_httpContext.Request.Host}/images/" + fileName + extension;
            Photo NewPhoto = new()
            {
                Url = ImageUrl,
            };

            appDbContext.Photos.Add(NewPhoto);
            appDbContext.SaveChanges();
        }
    }
}