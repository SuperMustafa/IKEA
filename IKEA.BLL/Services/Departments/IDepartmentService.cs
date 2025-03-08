using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.BLL.Dtos.Departments;
using IKEA.DAL.Models.Departments;

namespace IKEA.BLL.Services.Departments
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentToReturnDto> GetAllDepartments();
        DepartmentDetailsToReturnDto? GetDepartmentById(int id);
        int CreateDeparment(CreateDepartmentDto department);
        int UpdateDeparment(UpdateDepartmentDto department);
        bool DeleteDeparment(int id);
    }
}
