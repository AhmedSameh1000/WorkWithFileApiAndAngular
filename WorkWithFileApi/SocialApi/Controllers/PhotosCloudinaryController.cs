using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SocialApi.Helper;
using WorkWithFiles.Api.ViewModels;
using ZwajApp.api.IRepository;

namespace WorkWithFiles.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotosCloudinaryController : ControllerBase
    {
        private readonly IPhotoCloudinaryRepository _photoCloudinaryRepository;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;

        public PhotosCloudinaryController(
            IPhotoCloudinaryRepository photoCloudinaryRepository,
            IOptions<CloudinarySettings> CloudinaryConfig)
        {
            _photoCloudinaryRepository = photoCloudinaryRepository;
            _cloudinaryConfig = CloudinaryConfig;
        }

        [HttpPost("UploadImg")]
        public IActionResult UploadImg([FromForm] PhotoForCreateViewModel photoForCreateViewModel)
        {
            _photoCloudinaryRepository.UploadImage(photoForCreateViewModel);

            return Ok();
        }

        [HttpGet("Get/{id}")]
        public IActionResult GetImg(int id)
        {
            var Image = _photoCloudinaryRepository.GetImg(id);
            return Ok(Image);
        }

        [HttpDelete("Delete/{publicId}")]
        public IActionResult Delete(string publicId)
        {
            _photoCloudinaryRepository.DeleteImage(publicId);
            return Ok();
        }
    }
}