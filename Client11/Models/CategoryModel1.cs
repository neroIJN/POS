using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client11.Models
{
    public class CategoryModel1
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public int CategoryID { get; set; }
        public string ProductNameforImageInCategory { get; set; }
    }
}

