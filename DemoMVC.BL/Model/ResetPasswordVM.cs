using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DemoMVC.BL.Model
{
    public class ResetPasswordVM
    {

        [Required(ErrorMessage = "Password Required")]
        [MinLength(8, ErrorMessage = "Min Len 8")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password Required")]
        [MinLength(8, ErrorMessage = "Min Len 8")]
        [Compare("Password", ErrorMessage = "Password Not Match")]
        public string ConfirmPassword { get; set; }
    }
}
