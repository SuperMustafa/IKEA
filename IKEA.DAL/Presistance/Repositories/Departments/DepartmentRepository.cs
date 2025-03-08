using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Presistance.Data;
using Microsoft.EntityFrameworkCore;

namespace IKEA.DAL.Presistance.Repositories.Departments
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly ApplicationDbContext _context; // create a refernce of class ApplicationDbContext
        public DepartmentRepository(ApplicationDbContext dbContext)  // talk here to data base
        {
            _context = dbContext;

        
        }
        public IEnumerable<Department> GetAll(bool WithNoTracking = true)
        {
            if (WithNoTracking)
            {
                return _context.Departments.AsNoTracking().ToList();
            }
            return _context.Departments.ToList();
        }
        public Department? GetById(int id)
        {
            var Department = _context.Departments.Local.FirstOrDefault((D) => D.Id == id);
            return Department;
        }

        public int Add(Department department)
        {
            _context.Departments.Add(department);
            return _context.SaveChanges();
        }
        public int Update(Department department)
        {
            _context.Departments.Update(department);
            return _context.SaveChanges();
        }

        public int Delete(Department department)
        {
            _context.Departments.Remove(department);
            return _context.SaveChanges();
        }

        public IQueryable<Department> GetAllQueryable()
        {
            return _context.Departments;
        }
    }
}
