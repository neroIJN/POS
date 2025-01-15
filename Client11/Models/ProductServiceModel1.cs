using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client11.Models
{
    public class ProductServiceModel1
    {
        [PrimaryKey, AutoIncrement]
        public int ProductID { get; set; }
        //public string ProductName { get; set; }
        public string Price { get; set; }
        public string Stock { get; set; }
        public int CategoryID { get; set; }
    }
}
