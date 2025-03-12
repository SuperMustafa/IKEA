using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.BLL.Dtos.Employees;

namespace IKEA.BLL.Services.Employees
{
    public interface IEmployeeService
    {
        IEnumerable<EmployeeToReturnDto> GetAllEmployee();
        EmployeeDetailsToReturnDto? GetEmployeeById(int id);
        int CreateEmployee(CreateEmployeeDto employee);
        int UpdateEmployee(EmployeeToUpdateDto employee);
        bool DeleteEmployee(int id);
    }
}
