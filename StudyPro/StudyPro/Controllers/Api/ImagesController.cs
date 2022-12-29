using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudyPro.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public ImagesController(IWebHostEnvironment hostEnvironment)
        {
            this._hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> getAll()
        {
            var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads");
            var images = Directory.GetFiles(uploadsFolder)
                .Select(f => "/uploads/" + f.Split("\\").Last())
                .ToList();

            return Ok(images);

        }
    }
}
