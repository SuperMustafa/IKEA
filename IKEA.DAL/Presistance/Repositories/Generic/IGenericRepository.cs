using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Models.Employees;

namespace IKEA.DAL.Presistance.Repositories.Generic
{
    public interface IGenericRepository<T> where T : BaseModel
    {
        IEnumerable<T> GetAll(bool WithNoTracking = true);
        IQueryable<T> GetAllQueryable();
        IEnumerable<T> GetAllEnumerable();
        T? GetById(int id);
        int Add(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
