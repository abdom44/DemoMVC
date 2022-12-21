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
    public class CountryRep :ICountry
    {
        private readonly DemoContext db;

        public CountryRep(DemoContext db)
        {
            this.db = db;
        }
       

        public async Task<IEnumerable<Country>> GetAsync(Expression<Func<Country, bool>> filter = null)
        {
            if (filter == null)
                return await db.Country.ToListAsync();
            else
                return await db.Country.Where(filter).ToListAsync();
        }
    }
}
