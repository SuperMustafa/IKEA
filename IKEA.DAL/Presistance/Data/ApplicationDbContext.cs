using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departments;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using IKEA.DAL.Models.Employees;


namespace IKEA.DAL.Presistance.Data
{
    public class ApplicationDbContext:DbContext
    {
     
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder) // watch the changes at configurations classes and set it at database
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        
    }
}
