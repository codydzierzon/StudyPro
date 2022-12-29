 using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace StudyPro.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _hostEnvironment;

        public HomeController(IWebHostEnvironment hostEnvironment)
        {
            this._hostEnvironment = hostEnvironment;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(IFormFile? file)
        {
            if (file == null) return new ObjectResult(new { status = "fail" });

            var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var filePath = Path.Combine(uploadsFolder, file.FileName);
            await using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> Images()
        {
            var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "uploads");
            var images = Directory.GetFiles(uploadsFolder)
                .Select(f => f.Split("\\").Last())
                .ToList();

            return View(images);
        }
    }
}
