using AutoMapper;
using DemoMVC.BL.Helper;
using DemoMVC.BL.Intenfaces;
using DemoMVC.BL.Model;
using DemoMVC.DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.IO;

namespace DemoMVC.PL.Controllers
{
    public class EmployeeController : Controller
    {
        #region Fields

        private readonly IEmployee employee;
        private readonly IDepartment department;
        private readonly ICity city;
        private readonly IDistrict district;
        private readonly IMapper mapper;

        #endregion

        #region Ctor

        public EmployeeController(IEmployee employee, IDepartment department, IMapper mapper , ICity city , IDistrict district)
        {
            this.employee = employee;
            this.department = department;
            this.mapper = mapper;
            this.district = district;
            this.city = city;
        }
        
        #endregion

        #region Actions

        public async Task<IActionResult> Index(string SearchValue =null)
        {
            if (SearchValue == null)
            {
                var data = await employee.GetAsync(x => x.IsActive == true && x.IsDeleted == false);
                var result = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return View(result);
            }
            else
            {
                var data = await employee.GetAsync(x => x.IsActive == true && x.IsDeleted == false && x.Name.Contains(SearchValue) || x.Email.Contains(SearchValue));
                var result = mapper.Map<IEnumerable<EmployeeVM>>(data);
                return View(result);
            }

        }

        public async Task<IActionResult> Details(int id)
        {
            var data = await employee.GetByIdAsync(x => x.IsActive == true && x.IsDeleted == false && x.Id == id);
            var result = mapper.Map<EmployeeVM>(data);
            var DepartmentData = mapper.Map<IEnumerable<DepartmentVM>>(await department.GetAllAsync());
            ViewBag.DepartmentList = new SelectList(DepartmentData, "Id", "Name", result.DepatmentId);
            return View(result);
        }

        public async Task<IActionResult> Create()
        {
            var data = mapper.Map<IEnumerable<DepartmentVM>>(await department.GetAllAsync());
            ViewBag.DepartmentList = new SelectList(data , "Id","Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVM obj)
        {

            var Dptdata = mapper.Map<IEnumerable<DepartmentVM>>(await department.GetAllAsync());
            ViewBag.DepartmentList = new SelectList(Dptdata, "Id", "Name");

            try
            {


                if (ModelState.IsValid)
                {



                   
                    obj.CVName = FileUploader.UploadeFile("Docs",obj.CV);
                    obj.ImageName = FileUploader.UploadeFile("imgs", obj.Image);
                    var data = mapper.Map<Employee>(obj);
                    await employee.CreateAsync(data);
                    return RedirectToAction("Index");
                }

                TempData["Msg"] = "Validation Error";
                return View(obj);
            }
            catch (Exception ex)
            {
                TempData["Msg"] = ex.Message;
                return View(obj);
            }
        }
        
        public async Task<IActionResult> Update(int id)
        {
            var data = await employee.GetByIdAsync(x => x.IsActive&& x.IsDeleted==false && x.Id==id);
            var result = mapper.Map<EmployeeVM>(data);
            var DepartmentData = mapper.Map<IEnumerable<DepartmentVM>>(await department.GetAllAsync());
            ViewBag.DepartmentList = new SelectList(DepartmentData, "Id", "Name",result.DepatmentId);
            return View(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> Update(EmployeeVM obj)
        {
            var Dptdata = mapper.Map<IEnumerable<DepartmentVM>>(await department.GetAllAsync());
            ViewBag.DepartmentList = new SelectList(Dptdata, "Id", "Name", obj.DepatmentId);

            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Employee>(obj);
                    await employee.UpdateAsync(data);
                    return RedirectToAction("Index");
                }

                TempData["Msg"] = "Validation Error";
                return View(obj);
            }
            catch (Exception ex)
            {
                TempData["Msg"] = ex.Message;
                return View(obj);
            }
        }
        
        public async Task<IActionResult> Delete(int id)
        {
            var data = await employee.GetByIdAsync(x => x.IsActive == true && x.IsDeleted == false && x.Id == id);
            var result = mapper.Map<EmployeeVM>(data);
            var Dptdata = mapper.Map<IEnumerable<DepartmentVM>>(await department.GetAllAsync());
            ViewBag.DepartmentList = new SelectList(Dptdata, "Id", "Name", result.DepatmentId);
            return View(result);
        }
        
        [HttpPost]
        //[ActionName("Delete")]
        public async Task<IActionResult> Delete(EmployeeVM obj)
        {

            var Dptdata = mapper.Map<IEnumerable<DepartmentVM>>(await department.GetAllAsync());
            ViewBag.DepartmentList = new SelectList(Dptdata, "Id", "Name", obj.DepatmentId);

            try
            {
                FileUploader.RemoveFile("imgs", obj.ImageName);
                FileUploader.RemoveFile("Docs", obj.CVName);
                var data = mapper.Map<Employee>(obj);
                await employee.DeleteAsync(data.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Msg"] = ex.Message;
                return View(obj);
            }
        }

        #endregion

        #region Ajax Call
        [HttpPost]
        public async Task<JsonResult> GetCityByCounrtyId(int countyId)
        {
            var data  = await city.GetAsync(x=>x.CountryId==countyId);
            
            var res = mapper.Map<IEnumerable<CityVM>>(data);
            
            return Json(res);
        }
        [HttpPost]
        public async Task<JsonResult> GetDistrictByCityId(int cityId)
        {

            var data =await district.GetAsync(x => x.CityId == cityId);
            var res = mapper.Map<IEnumerable<DistrictVM>>(data);
            return Json(res);
        }
        //[HttpPost]
        //public async Task<JsonResult> GetCityDataByCountryId(int CntryId)
        //{
        //    var data = await city.GetAsync(a => a.CountryId == CntryId);
        //    var result = mapper.Map<IEnumerable<CityVM>>(data);
        //    return Json(result);
        //}


        //[HttpPost]
        //public async Task<JsonResult> GetDistrictDataByCityId(int CtyId)
        //{
        //    var data = await district.GetAsync(a => a.CityId == CtyId);
        //    var result = mapper.Map<IEnumerable<DistrictVM>>(data);
        //    return Json(result);
        //}

        #endregion


    }
}
