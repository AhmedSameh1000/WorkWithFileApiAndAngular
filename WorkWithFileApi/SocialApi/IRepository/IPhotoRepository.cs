using ZwajApp.api.ViewModels;

namespace ZwajApp.api.IRepository
{
    public interface IPhotoRepository
    {
        void UploadImage(PhotoForDetailsDto photo);

        void DeleteImage(int id);
    }
}