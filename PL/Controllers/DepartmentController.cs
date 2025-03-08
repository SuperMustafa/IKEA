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
            var departments = _departmentService.GetAllDepartments();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(CreateDepartmentDto department)
        {
            if (!ModelState.IsValid)
            {

                return View(department);

            }
            var message = string.Empty;

            try {
                var result = _departmentService.CreateDeparment(department);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    message = "No Department Has been Created";
                    ModelState.AddModelError(string.Empty, message);
                    return View(department);

                }


            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                if (_environment.IsDevelopment())
                {
                    message = ex.Message;
                    return View(department);

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

                return BadRequest();

            var department = _departmentService.GetDepartmentById(id.Value);
            if (department is null)

                return NotFound();

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

            return View(new DepartmentEditViewModel()
            {
                Code = department.Code,
                Name = department.Name,
                CreationDate = department.CreationDate,
                Description = department.Description,

            });

        }

        [HttpPost]
        public IActionResult Edit(int id, DepartmentEditViewModel department)
        {
            if (!ModelState.IsValid)
            {

                return View(department);

            }
            var message = string.Empty;

            try
            {
                var result = _departmentService.UpdateDeparment(new UpdateDepartmentDto()
                {
                    Id = id,
                    Code = department.Code,
                    Name = department.Name,
                    CreationDate = department.CreationDate,
                    Description = department.Description,


                });
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    message = "No Department Has been Updated";
                    ModelState.AddModelError(string.Empty, message);
                    return View(department);

                }


            }
            catch (Exception ex)
            {
                message = _environment.IsDevelopment() ? ex.Message : "No Department Has been Updated";
            }
            return View(department);
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
                    return RedirectToAction(nameof(Index));
                    message = "An Error Happend While Deleteing the department";
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
    


