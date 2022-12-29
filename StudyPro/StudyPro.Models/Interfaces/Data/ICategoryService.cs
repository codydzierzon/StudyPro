using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyPro.Models.DTO;

namespace StudyPro.Models.Interfaces.Data
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task<Category> AddCategoryAsync(Category category);
    }
}
