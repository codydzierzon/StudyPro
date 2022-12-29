using Microsoft.AspNetCore.Mvc;
using StudyPro.Models.DTO;
using StudyPro.Models.Interfaces.Data;

namespace StudyPro.Controllers.Api
{
    [ApiController]
    [Route("/api/[controller]")]
    public class CategoriesController: ControllerBase
    {
        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("")]
        public async Task<IActionResult> GetCategories()
        {
            try
            {
                var categories = await _categoryService.GetAllAsync();
                return Ok(categories);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        [HttpPost("")]
        public async Task<IActionResult> addCategories(Category category)
        {
            var addCategory = await _categoryService.AddCategoryAsync(category);
            return StatusCode(201, addCategory);
        }
    }
}
