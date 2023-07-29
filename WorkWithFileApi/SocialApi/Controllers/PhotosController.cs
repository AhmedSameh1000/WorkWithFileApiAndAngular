using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ZwajApp.api.IRepository;
using ZwajApp.api.ViewModels;

namespace ZwajApp.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoRepository IphotoRepo;

        public PhotosController(IPhotoRepository IphotoRepo)
        {
            this.IphotoRepo = IphotoRepo;
        }

        [HttpPost("UploadImg")]
        public IActionResult UploadImage([FromForm] PhotoForDetailsDto model)
        {
            IphotoRepo.UploadImage(model);
            return Ok(model);
        }

        [HttpPost("DeleteImg")]
        public IActionResult DeleteImage(int id)
        {
            IphotoRepo.DeleteImage(id);
            return Ok(id);
        }
    }
}