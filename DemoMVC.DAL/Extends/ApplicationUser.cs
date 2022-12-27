using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.DAL.Extends
{
    public class ApplicationUser:IdentityUser
    {
        public bool IsAgree { get; set; }
    }
}
