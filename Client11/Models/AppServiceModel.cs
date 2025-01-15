using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client11.Models
{
    
    public class AppServiceModel
    {
        [PrimaryKey, AutoIncrement]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }    
        public string Email { get; set; }   
        public string Gender { get; set; }
    }
}
