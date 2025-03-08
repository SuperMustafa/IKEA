using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departments;

namespace IKEA.DAL.Presistance.Repositories.Departments
{
    public interface IDepartmentRepository
    {
        //interface do not know access modifies at its attributes and functions
        IEnumerable<Department> GetAll(bool WithNoTracking = true);
        IQueryable<Department> GetAllQueryable();
        Department? GetById(int id);
        int Add(Department department);
        int Update(Department department);
        int Delete(Department department);
    }
}
