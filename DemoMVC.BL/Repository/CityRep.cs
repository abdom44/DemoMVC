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
    public class CityRep : ICity
    {
        private readonly DemoContext db;

        public CityRep(DemoContext db)
        {
            this.db = db;
        }
       

        public async Task<IEnumerable<City>> GetAsync(Expression<Func<City, bool>> filter = null)
        {
            if (filter == null)
                return await db.City.ToListAsync();
            else
                return await db.City.Where(filter).ToListAsync();
        }
    }
}
