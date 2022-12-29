using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyPro.Models.DTO
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Column("Category")]
        public string CategoryName { get; set; }
    }
}
