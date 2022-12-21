using DemoMVC.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.BL.Intenfaces
{
    public interface IDistrict
    {
        Task<IEnumerable<District>> GetAsync(Expression<Func<District, bool>> filter = null);
    }
}

