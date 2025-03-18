using Microsoft.AspNetCore.Mvc;
using IKEA.BLL.Services.Departments;
using IKEA.BLL.Dtos.Departments;
using IKEA.PL.ViewModels.Department;

namespace IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        private readonly ILogger _logger;
        private readonly IWebHostEnvironment _environment;

        public DepartmentController(IDepartmentService departmentService, ILogger<DepartmentController> logger, IWebHostEnvironment environment)
        {

            _departmentService = departmentService;
            _logger = logger;
            _environment = environment;
        }




        [HttpGet]
        public IActionResult Index()
        {
            //ViewData["text"] = "Hello from Index";   //viewbag and viewdata talks to same storage
            //ViewBag.Message = "Hello from Index";
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Create(DepartmentViewModel departmentVm)
        {
            if (!ModelState.IsValid)
            {

                return View(departmentVm);

            }
            var message = string.Empty;

            try {
                var result = _departmentService.CreateDeparment(new CreateDepartmentDto() 
                {
                    Name =departmentVm.Name,
                    Code =departmentVm.Code,
                    Description =departmentVm.Description,
                    CreationDate =departmentVm.CreationDate,
                });
                if (result > 0)
                {
                    TempData["Message"] = "Department Created Successfully";
                }
                else
                {
                   
                    message = "No Department Has been Created";
                    TempData["Message"] = message;
                    ModelState.AddModelError(string.Empty, message);

                }
              return  RedirectToAction("Index");


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                if (_environment.IsDevelopment())
                {
                    message = ex.Message;
                    return View(departmentVm);

                }
                else
                {
                    message = "No Department Has been Created";
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


            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null)
            
            {
                return NotFound();


            }


            return View(department);

        }
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id is null)

                return BadRequest();

            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null)

                return NotFound();

            return View(new DepartmentViewModel()
            {
                Code = department.Code,
                Name = department.Name,
                CreationDate = department.CreationDate,
                Description = department.Description,

            });

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(int id, DepartmentViewModel departmentVm)
        {
            if (!ModelState.IsValid)
            {

                return View(departmentVm);

            }
            var message = string.Empty;

            try
            {
                var result = _departmentService.UpdateDeparment(new UpdateDepartmentDto()
                {
                    Id = id,
                    Code = departmentVm.Code,
                    Name = departmentVm.Name,
                    CreationDate = departmentVm.CreationDate,
                    Description = departmentVm.Description,


                });
                if (result > 0)
                {
                    TempData["Message"] = "Department Has been Updated Successfully";
                }
                else
                {
                    message = "No Department Has been Updated";
                    TempData["Message"] = message;
                    ModelState.AddModelError(string.Empty, message);
                    

                }
                return RedirectToAction("Index");
                
                



            }
            catch (Exception ex)
            {
                message = _environment.IsDevelopment() ? ex.Message : "No Department Has been Updated";
            }
            return View(departmentVm);
        }
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null)

                return BadRequest();

            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null)

                return NotFound();
            return View(department);



        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _departmentService.DeleteDeparment(id);
            var message = string.Empty;
            try
            {
                if (result)
                {
                    TempData["Message"] = "Department Deleted Successfully";

                    return RedirectToAction(nameof(Index));
                   
                }
                else
                {
                    message = "An Error Happend While Deleteing the department";
                    TempData["Message"] = message;
                }
                }




            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                message = _environment.IsDevelopment() ? ex.Message : "An Error Happend While Deleteing the department";
            }
            return View(nameof(Index));


        }
    } 
}
    


