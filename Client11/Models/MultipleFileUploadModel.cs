using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SQLite;
namespace Client11.Models
{
    public class MultipleFileUploadModel
    {
        [PrimaryKey]
        public string FielId { get; set; }
        public string FileName { get; set; }
        public byte[] ImageData { get; set; }
        public string ProductnameForImage { get; set; }
    }
}
