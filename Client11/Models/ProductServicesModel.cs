using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client11.Models
{
    public class ProductServicesModel
    {
        /*
        public int Id { get; set; } 
        public string Name { get; set; }
        public int? Price { get; set; }
        public int? Stock { get; set; }
        public string CategoryId { get; set; } 
        public string CategoryName { get; set; }
        public string ImageUrl { get; set; }
        public string FileName { get; set; }
        public byte[] FileContent { get; set; } 
        public bool CartFlag { get; set; }


        */


       
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }
        public string ProductName { get; set; }
        public string Price { get; set; }
        public string Stock { get; set; }
        
        public string Category111 { get; set; }

        public List<MultipleFileUploadModel> ImageFiles;

        public int? FielId { get; set; }

        public string FileName { get; set; }
        public byte[] ImageData { get; set; }

        public string ImageFileName { get; set; }
        public bool Expanded { get; set; }
    }
}
