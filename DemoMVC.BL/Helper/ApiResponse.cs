using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.BL.Helper
{
    public class ApiResponse<T>
    {
        public string Code { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
