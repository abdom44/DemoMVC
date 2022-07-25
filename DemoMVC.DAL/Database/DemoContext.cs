using DemoMVC.DAL.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.DAL.Database
{
    public class DemoContext:DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> opt) :base(opt)
        {

        }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}
