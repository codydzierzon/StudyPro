using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyPro.Models.DTO
{
    [Table("Card")]
    public class Card
    {
        [Key]
        public int CardID { get; set; }
        public int CategoryID { get; set; }
        public string Term { get; set; }
        public int Level { get; set; }
        public string Definition { get; set; }
        public string? Question { get; set; }
        public string? ImagePath { get; set; }
    }
}
