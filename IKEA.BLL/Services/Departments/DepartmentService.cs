using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.BLL.Dtos.Departments;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Presistance.Repositories.Departments;
using Microsoft.EntityFrameworkCore;

namespace IKEA.BLL.Services.Departments
{
    public class DepartmentService : IDepartmentService
    {
        public readonly IDepartmentRepository _departmentRepository; // talk to department repoistory that talkes to database
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IEnumerable<DepartmentToReturnDto> GetAllDepartments()
        {
            
           var departments = _departmentRepository.GetAllQueryable().Where(D=>!D.IsDeleted).Select(D => new DepartmentToReturnDto
            {
                Description = D.Description,
                Name = D.Name,
                Code = D.Code,
                CreationDate = D.CreationDate,
                Id = D.Id,
            }).AsNoTracking().ToList();
            return departments;
        }

        public DepartmentDetailsToReturnDto? GetDepartmentById(int id)
        {
            var department =_departmentRepository.GetById(id);
            if (department != null) 
            {
                return new DepartmentDetailsToReturnDto
                {
                    Description = department.Description,
                    Code = department.Code,
                    CreatedBy = department.CreatedBy,
                    CreatedOn = department.CreatedOn,
                    CreationDate = department.CreationDate,
                    Id = id,
                    IsDeleted = department.IsDeleted,
                    LastModificationBy = department.LastModificationBy,
                    LastModificationOn = department.LastModificationOn,
                    Name = department.Name,

                }; 
               
            
            }
            return null;
        }
        public int CreateDeparment(CreateDepartmentDto department)
        {
            var CreatedDepartment = new Department
            {
                Description = department.Description,
                Name = department.Name,
                Code = department.Code,
                CreationDate = department.CreationDate,
                CreatedBy = 1,
                LastModificationBy = 1,
                LastModificationOn = DateTime.UtcNow,




            };
            return _departmentRepository.Add(CreatedDepartment);
        }

       

        public int UpdateDeparment(UpdateDepartmentDto department)
        {
            var UpdatedDepartment = new Department
            {
                Id = department.Id, 
                Description = department.Description,
                Name = department.Name,
                Code = department.Code,
                CreationDate = department.CreationDate,
                CreatedBy = 1,
                LastModificationBy = 1,
                LastModificationOn = DateTime.UtcNow,




            };
            return _departmentRepository.Update(UpdatedDepartment);
        }

        public bool DeleteDeparment(int id)
        {
            var department=_departmentRepository.GetById(id);
            if (department != null) 
            {
                return _departmentRepository.Delete(department) > 0;
            
            }
            return false;
        }

        
    }
}
