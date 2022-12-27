using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DemoMVC.BL.Model
{
    public class LoginVM
    {

        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Invalid mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password Required")]
        [MinLength(8, ErrorMessage = "Min Len 8")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }


    }
}
