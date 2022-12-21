using DemoMVC.BL.Intenfaces;
using DemoMVC.DAL.Database;
using DemoMVC.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.BL.Repository
{
    public class DistrictRep :IDistrict
    {
        private readonly DemoContext db;

        public DistrictRep(DemoContext db)
        {
            this.db = db;
        }
       

        public async Task<IEnumerable<District>> GetAsync(Expression<Func<District, bool>> filter = null)
        {
            if (filter == null)
                return await db.District.ToListAsync();
            else
                return await db.District.Where(filter).ToListAsync();
        }
    }
}
