using DemoMVC.BL.Model;
using DemoMVC.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoMVC.BL.Intenfaces
{
    public interface IDepartment
    {
        Task<IEnumerable<Department>> GetAllAsync();
        Task CreateAsync(Department departmentVM);
        Task UpdateAsync(Department departmentVM);
        Task DeleteAsync(int id);
        Task<Department> GetByIdAsync(int id); 
    }
}
