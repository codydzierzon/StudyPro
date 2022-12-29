using Microsoft.EntityFrameworkCore;
using StudyPro.Models.DTO;

namespace StudyPro.Services.Data.EF
{
    public class StudyProDataContext: DbContext
    {
        public StudyProDataContext(DbContextOptions<StudyProDataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
