﻿using Microsoft.AspNetCore.Mvc;
using IKEA.BLL.Services.Departments;
using IKEA.BLL.Dtos.Departments;
using IKEA.PL.ViewModels.Department;
using IKEA.BLL.Services.Employees;
using IKEA.BLL.Dtos.Employees;
using IKEA.DAL.Common.Enums;
using IKEA.PL.ViewModels.Employee;

namespace IKEA.PL.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _environment;

        public EmployeeController(IEmployeeService employeeService, ILogger<EmployeeController> logger, IWebHostEnvironment environment)
        {

            _employeeService = employeeService;
            _logger = logger;
            _environment = environment;
        }




        [HttpGet]
        public IActionResult Index()
        {
            var employees = _employeeService.GetAllEmployee();
            return View(employees);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(EmployeeViewModel employeeVm)
        {
            if (!ModelState.IsValid)
            {

                return View(employeeVm);

            }
            var message = string.Empty;

            try {
                var result = _employeeService.CreateEmployee(new CreateEmployeeDto()
                {
                    Name = employeeVm.Name,
                    Address = employeeVm.Address,
                    Age= employeeVm.Age,
                    Email= employeeVm.Email,
                    EmployeeType= employeeVm.EmployeeType,
                    Gender= employeeVm.Gender,
                    HiringDate= employeeVm.HiringDate,
                    IsActive= employeeVm.IsActive,
                    PhoneNumber= employeeVm.PhoneNumber,
                    Salary = employeeVm.Salary

                });
                if (result > 0)
                {
                    TempData["Message"] = "Employee Created Successfully";
                    
                }
                else
                {
                    message = "No Employee Has been Created";
                    TempData["Message"] = message;
                    ModelState.AddModelError(string.Empty, message);

                }
                return RedirectToAction("Index");


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                if (_environment.IsDevelopment())
                {
                    message = ex.Message;
                    return View(employeeVm);

                }
                else
                {
                    message = "No Employee Has been Created";
                    return View("Error", message);
                }
            }
        }
        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id is null)
            {
                return BadRequest();


            }


            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null)
            
            {
                return NotFound();


            }


            return View(employee);

        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)

                return BadRequest();

            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null)

                return NotFound();

            return View(new EmployeeViewModel()
            {
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate, 
                Gender =Enum.TryParse<Gender>(employee.Gender,out var gender) ? gender : default ,
                EmployeeType= Enum.TryParse<EmployeeType>(employee.EmployeeType, out var empType) ? empType : default
            });

        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(int id, EmployeeViewModel employeeVm)
        {
            if (!ModelState.IsValid)
            {

                return View(employeeVm);

            }
            var message = string.Empty;

            try
            {
                var result = _employeeService.UpdateEmployee(new EmployeeToUpdateDto() 
                {
                    Id=employeeVm.Id,
                    Name=employeeVm.Name,
                    Address=employeeVm.Address,
                    Salary=employeeVm.Salary,
                    IsActive=employeeVm.IsActive,
                    Email=employeeVm.Email,
                    PhoneNumber=employeeVm.PhoneNumber,
                    HiringDate=employeeVm.HiringDate,
                    Age = employeeVm.Age,
                    EmployeeType = employeeVm.EmployeeType,
                    Gender = employeeVm.Gender
                    
                    
                });
               
                if (result > 0)
                {
                    TempData["Message"] = "Employee Updated Successfully";
                }
                else
                {
                    message = "No Employee Has been Updated";
                    TempData["Message"] = message;  
                    ModelState.AddModelError(string.Empty, message);

                }

                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                message = _environment.IsDevelopment() ? ex.Message : "No Employee Has been Updated";
            }
            return View(employeeVm);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)

                return BadRequest();

            var employee = _employeeService.GetEmployeeById(id.Value);
            if (employee is null)

                return NotFound();
            return View(employee);



        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _employeeService.DeleteEmployee(id);
            var message = string.Empty;
            try
            {
                if (result)
                {
                    return RedirectToAction(nameof(Index));
                    //message = "An Error Happend While Deleteing the Employee";
                }
                }




            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                message = _environment.IsDevelopment() ? ex.Message : "An Error Happend While Deleteing the Employee";
            }
            return View(nameof(Index));


        }
    } 
}
    


