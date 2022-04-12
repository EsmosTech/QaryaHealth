using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QaryaHealth.Service.Interfaces;
using System.IO;
using System.Threading.Tasks;

namespace QaryaHealth.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UploadImageController : ControllerBase
    {
        private readonly IUploadImageService _uploadImageService;
        public UploadImageController(IUploadImageService uploadImageService)
        {
            _uploadImageService = uploadImageService;
        }

        [HttpPost]
        public async Task<int> Upload(IFormFile Image)
        {
            byte[] imageBytes = null;
            using (var fs = Image.OpenReadStream())
            using (var ms = new MemoryStream())
            {
                fs.CopyTo(ms);
                imageBytes = ms.ToArray();
            }

            return await _uploadImageService.UploadAsync(imageBytes);
        }

    }
}
