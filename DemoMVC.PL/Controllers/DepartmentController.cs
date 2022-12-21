using AutoMapper;
using DemoMVC.BL.Intenfaces;
using DemoMVC.BL.Model;
using DemoMVC.BL.Repository;
using DemoMVC.DAL.Entity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DemoMVC.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartment department;
        private readonly IMapper mapper;

        public DepartmentController(IDepartment department , IMapper mapper)
        {
            this.department = department;
            this.mapper = mapper;
        }
     
        public async Task<IActionResult> Index()

        {
            var data = await department.GetAllAsync();
            var result = mapper.Map<IEnumerable<DepartmentVM>> (data);

            return View(result);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DepartmentVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = mapper.Map<Department>(obj);
                    await department.CreateAsync(result);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["message"] = "vaidation errors"
                       ;
                    return View(obj);
                }
               
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                return View(obj);
            }
        }
        public async Task<IActionResult> Details(int id)
        {
            var d =  await department.GetByIdAsync(id);
            var result = mapper.Map<DepartmentVM>(d);


            return View(result);
        }
        public async Task<IActionResult> Update(int id)
        {
            var d = await department.GetByIdAsync(id);
            var result = mapper.Map<DepartmentVM>(d); 
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Update(DepartmentVM obj)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var data = mapper.Map<Department>(obj);
                    await department.UpdateAsync(data);
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["message"] = "vaidation errors";
                    return View(obj);
                }

            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                return View(obj);
            }

        }
        public async Task<IActionResult> Delete(int id)
        {
            var d = await department.GetByIdAsync(id);
            return View(d);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(DepartmentVM obj)
        {
            try
            {
                await department.DeleteAsync(obj.Id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["message"] = ex.Message;
                return View(obj);
            }

        }
    }
}
