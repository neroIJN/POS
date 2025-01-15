using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client11.Models
{
    
    public class LoginModel
    {
        [Required]
        public string EmailAdress { get; set; }
        [Required]
        public string Password { get; set; }    
    }
}
