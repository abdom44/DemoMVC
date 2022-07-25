using DemoMVC.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.BL.Intenfaces
{
    public interface IEmployee
    {
        Task<IEnumerable<Employee>> GetAsync(Expression<Func<Employee, bool>> filter = null);
        Task CreateAsync(Employee departmentVM);
        Task UpdateAsync(Employee departmentVM);
        Task DeleteAsync(int id);
        Task<Employee> GetByIdAsync(Expression<Func<Employee, bool>> filter);
    }
}
