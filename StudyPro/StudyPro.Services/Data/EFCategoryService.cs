using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudyPro.Models.DTO;
using StudyPro.Models.Interfaces.Data;
using StudyPro.Services.Data.EF;

namespace StudyPro.Services.Data
{
    public class EFCategoryService: ICategoryService
    {
        private StudyProDataContext _db;

        public EFCategoryService(StudyProDataContext db)
        {
            _db = db;
        }


        public async Task<List<Category>> GetAllAsync()
        {
            return await _db.Categories.ToListAsync();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await  _db.Categories.FindAsync(id);
        }
        public async Task<Category> AddCategoryAsync(Category category)
        {
            _db.Categories.Add(category);

            await _db.SaveChangesAsync();

            return category;
        }
    }

}
