using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Presistance.Repositories.Generic;

namespace IKEA.DAL.Presistance.Repositories.Departments
{
    public interface IDepartmentRepository:IGenericRepository<Department>
    {
        //interface do not know access modifies at its attributes and functions
       
    }
}
