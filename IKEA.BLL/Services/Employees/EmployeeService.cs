using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.BLL.Dtos.Employees;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Presistance.Repositories.Employees;

namespace IKEA.BLL.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public IEnumerable<EmployeeToReturnDto> GetAllEmployee()
        {
         var query = _employeeRepository.GetAllEnumerable().Where(E=>!E.IsDeleted).Select(employee => new EmployeeToReturnDto()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Email = employee.Email,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                EmployeeType = employee.EmployeeType.ToString(),
                Gender = employee.Gender.ToString()
            });
            var employees = query.ToList();
            var count=employees.Count();
            var firstEmployee = query.FirstOrDefault();
            return query;
        }

        public EmployeeDetailsToReturnDto? GetEmployeeById(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee != null)
            {
                return new EmployeeDetailsToReturnDto()
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Age = employee.Age,
                    Email = employee.Email,
                    Salary = employee.Salary,
                    IsActive = employee.IsActive,
                    PhoneNumber = employee.PhoneNumber,
                    EmployeeType = employee.EmployeeType.ToString(),
                    Gender = employee.Gender.ToString(),
                    Address = employee.Address,
                    CreatedBy = employee.CreatedBy,
                    CreatedOn = employee.CreatedOn,
                    LastModificationBy = employee.LastModificationBy,
                    LastModificationOn = employee.LastModificationOn,
                    HiringDate = employee.HiringDate,
                    IsDeleted = employee.IsDeleted,


                };


            }
            else { return null!; }
        }

        public int CreateEmployee(CreateEmployeeDto employeeDto)
        {
            Employee employee = new Employee()
            {
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                Email = employeeDto.Email,
                Salary = employeeDto.Salary,
                PhoneNumber = employeeDto.PhoneNumber,
                IsActive = employeeDto.IsActive,
                HiringDate = employeeDto.HiringDate,
                Gender = employeeDto.Gender,
                CreatedBy = 1,
                LastModificationBy = 1,
                LastModificationOn = DateTime.UtcNow,
                EmployeeType= employeeDto.EmployeeType,

            };
            return _employeeRepository.Add(employee);
        }

        public int UpdateEmployee(EmployeeToUpdateDto employeeDto)
        {
            Employee employee = new Employee()
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Age = employeeDto.Age,
                Address = employeeDto.Address,
                Email = employeeDto.Email,
                Salary = employeeDto.Salary,
                PhoneNumber = employeeDto.PhoneNumber,
                IsActive = employeeDto.IsActive,
                HiringDate = employeeDto.HiringDate,
                Gender = employeeDto.Gender,
                EmployeeType=employeeDto.EmployeeType,
                CreatedBy = 1,
                LastModificationBy = 1,
                LastModificationOn = DateTime.UtcNow,
            };
            return _employeeRepository.Update(employee);
        }


        public bool DeleteEmployee(int id)
        {
            var employee = _employeeRepository.GetById(id);
            if (employee != null)
            {
                return _employeeRepository.Delete(employee) > 0;
            }
            return false;
        }



    }
}
