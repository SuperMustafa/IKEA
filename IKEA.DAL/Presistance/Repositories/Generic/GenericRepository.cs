using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Presistance.Data;
using Microsoft.EntityFrameworkCore;

namespace IKEA.DAL.Presistance.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T: BaseModel
    {
        private readonly ApplicationDbContext _context; // create a refernce of class ApplicationDbContext
        public GenericRepository(ApplicationDbContext dbContext)  // talk here to data base
        {
            _context = dbContext;


        }
        public IEnumerable<T> GetAll(bool WithNoTracking = true)
        {
            if (WithNoTracking)
            {
                return _context.Set<T>().Where(X=>!X.IsDeleted).AsNoTracking().ToList();
            }
            return _context.Set<T>().Where(X => !X.IsDeleted).ToList();
        }
        public T? GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public int Add(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChanges();
        }
        public int Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return _context.SaveChanges();
        }

        public int Delete(T entity)
        {
            //_context.Set<T>().Remove(entity);
            //return _context.SaveChanges();
            entity.IsDeleted = true;
            _context.Set<T>().Update(entity);
            return _context.SaveChanges();
        }

        public IQueryable<T> GetAllQueryable()
        {
            return _context.Set<T>();
        }
  
    }
}
