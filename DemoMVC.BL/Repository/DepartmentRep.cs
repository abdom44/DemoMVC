using DemoMVC.BL.Intenfaces;
using DemoMVC.BL.Model;
using DemoMVC.DAL.Database;
using DemoMVC.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.BL.Repository
{
    public class DepartmentRep : IDepartment
    {
        private readonly DemoContext db ;
        public DepartmentRep(DemoContext db)
        {
                this.db = db;
        }
        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            var data = await db.Department.ToListAsync();
            return data;
        }
        public async Task<Department> GetByIdAsync(int id)
        {
            var data = await db.Department.Where(a => a.Id == id).FirstOrDefaultAsync();
            return data;

        }
        public async Task CreateAsync(Department obj)
        {
            await db.Department.AddAsync(obj);
            await db.SaveChangesAsync();
        }
        public async Task UpdateAsync(Department obj)
        {
           db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var data = await db.Department.FindAsync(id);
            db.Department.Remove(data);
            await db.SaveChangesAsync();
        }
    }
}
