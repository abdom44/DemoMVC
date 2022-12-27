using DemoMVC.DAL.Entity;
using DemoMVC.DAL.Extends;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.DAL.Database
{
    public class DemoContext : IdentityDbContext<ApplicationUser>
    {
        public DemoContext(DbContextOptions<DemoContext> opt) :base(opt)
        {

        }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
    }
}
