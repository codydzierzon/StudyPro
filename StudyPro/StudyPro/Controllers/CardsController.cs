using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using StudyPro.Models;
using StudyPro.Models.Interfaces.Data;

namespace StudyPro.Controllers
{
    public class CardsController : Controller
    {
        private ICardService _cardService;

        private ICategoryService _categoryService;

        private readonly IWebHostEnvironment _hostEnvironment;

        public CardsController(ICardService cardService, ICategoryService categoryService, IWebHostEnvironment hostEnvironment)
        {
            _cardService = cardService;
            _categoryService = categoryService;
            this._hostEnvironment = hostEnvironment;
        }

        public async Task<IActionResult> Index(int? id)
        {
            Console.WriteLine(id);
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var card = await _cardService.GetByIDAsync(id);
            var categories = await _categoryService.GetAllAsync();
            var model = new CardEditModel() 
            {
                Categories = categories,
                Card = card
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile? file, int id)
        {
            if (file == null) return new ObjectResult(new { status = "fail" });

            var uploadsFolder = Path.Combine(_hostEnvironment.WebRootPath, "cards");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var extension = Path.GetExtension(file.FileName);
            var filename = $"{id}{extension}";
            var filePath = Path.Combine(uploadsFolder, filename);
            await using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            // update the card table with the filename
            // path should be /cards/1.jpg
            var imagePath = $"/cards/{filename}";
            await _cardService.AddImageToCardAsync(id, imagePath);
            return Ok(imagePath);

        }
    }

}
