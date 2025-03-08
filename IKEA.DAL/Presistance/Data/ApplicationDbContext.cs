using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Models.Departments;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace IKEA.DAL.Presistance.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext() : base()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=.; Database=IKEA; Trusted_Connection=true; TrustServerCertificate=true");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder) // watch the changes at configurations classes and set it at database
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<Department> Departments { get; set; }  
    }
}
