using Microsoft.AspNetCore.Mvc;
using StudyPro.Models;
using StudyPro.Models.Interfaces.Data;

namespace StudyPro.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet()]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            var categories = await _categoryService.GetAllAsync();
            var model = new CategoryDetailsModel()
            {
                Category = category,
                Categories = categories
            };
            return View(model);
        }
    }
}
