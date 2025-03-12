using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Presistance.Repositories.Generic;

namespace IKEA.DAL.Presistance.Repositories.Employees
{
    public interface IEmployeeRepository:IGenericRepository<Employee>
    {
      
    }
}
