using AutoMapper;
using DemoMVC.BL.Helper;
using DemoMVC.BL.Intenfaces;
using DemoMVC.BL.Model;
using DemoMVC.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee employee;
        private readonly IMapper mapper;

        public EmployeeController( IEmployee employee , IMapper mapper )
        {
            this.employee = employee;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("~/api/employee/get")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var data = await employee.GetAsync(x => x.IsActive == true && x.IsDeleted == false);
                var result = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return Ok(new ApiResponse<IEnumerable<EmployeeVM>>
                {
                    Code= "200",
                    Status = "OK",
                    Message="Data Found",
                    Data = result
                });

            }
            catch (Exception e)
            {
                return NotFound(new ApiResponse<string>
                {
                    Code = "400",
                    Status = "Not Found",
                    Message= "No Data Found",
                    Data = e.Message
                });                ;
            }

        }
        [HttpGet]
        [Route("~/api/employee/GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var data = await employee.GetByIdAsync(x => x.IsActive == true && x.IsDeleted == false&&x.Id==id);
                var result = mapper.Map<EmployeeVM>(data);
                return Ok(new ApiResponse<EmployeeVM>
                {
                    Code = "200",
                    Status = "OK",
                    Message = "Data Found",
                    Data = result
                });

            }
            catch (Exception e)
            {
                return NotFound(new ApiResponse<string>
                {
                    Code = "400",
                    Status = "Not Found",
                    Message = "No Data Found",
                    Data = e.Message
                }); ;
            }

        }
        [HttpPost]
        [Route("~/api/employee/PostEmployee")]
        public async Task<IActionResult>PostEmployee(EmployeeVM employeeVM)
        {
            

            try
            {
                var data = await employee.CreateAsync(mapper.Map<Employee>(employeeVM));
                var obj  = mapper.Map<EmployeeVM>(data);
                return Ok(new ApiResponse<EmployeeVM>
                {
                    Code = "201",
                    Status = "Created",
                    Message= "Data Saved",
                    Data  = obj
                });
            }
            catch (Exception e)
            {
                return NotFound(new ApiResponse<string>
                {
                    Code = "400",
                    Status = "Not Found",
                    Message = "No Data Saved",
                    Data = e.Message
                });

            }
            
        }

        [HttpPut]
        [Route("~/api/employee/PutEmployee")]
        public async Task<IActionResult> PutEmployee(EmployeeVM obj)
        {


            try
            {
                var result = mapper.Map<Employee>(obj);
                await employee.UpdateAsync(result);

                return Ok(new ApiResponse<string>
                {
                    Code = "202",
                    Status = "Accepted",
                    Message = "Data Updated",
                    Data = "Data Updated"

                });
            }
            catch (Exception e)
            {
                return NotFound(new ApiResponse<Exception>
                {
                    Code = "400",
                    Status = "Not Found",
                    Message = "No Data Saved",
                    Data = e.InnerException
                });

            }

        }

        [HttpDelete]
        [Route("~/api/employee/DeleteEmployee/{id}")]
        public async Task<IActionResult> PutEmployee(int id)
        {


            try
            {
               
                await employee.DeleteAsync(id);

                return Ok(new ApiResponse<string>
                {
                    Code = "202",
                    Status = "Deleted",
                    Message = "Data Deleted",
                    Data = "Data Deleted"

                });
            }
            catch (Exception e)
            {
                return NotFound(new ApiResponse<string>
                {
                    Code = "400",
                    Status = "Not Found",
                    Message = "No Data Saved",
                    Data = e.Message
                });

            }

        }
    }
}
