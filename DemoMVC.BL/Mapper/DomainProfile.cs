﻿using AutoMapper;
using DemoMVC.BL.Model;
using DemoMVC.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BL.Mapper
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Department, DepartmentVM>();
            CreateMap<DepartmentVM, Department>();
            
            CreateMap<Employee, EmployeeVM>();
            CreateMap<EmployeeVM, Employee>();
        }
    }
}
