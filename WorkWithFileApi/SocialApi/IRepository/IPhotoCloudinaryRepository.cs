using WorkWithFiles.Api.Models;
using WorkWithFiles.Api.ViewModels;
using ZwajApp.api.RepositoryEmplmentation;

namespace ZwajApp.api.IRepository
{
    public interface IPhotoCloudinaryRepository
    {
        void UploadImage(PhotoForCreateViewModel photo);

        CloudinaryPhoto GetImg(int id);

        void DeleteImage(string publicId);
    }
}