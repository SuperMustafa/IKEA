using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Common.Enums;

namespace IKEA.BLL.Dtos.Employees
{
    public class EmployeeToReturnDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Salary { get; set; }
        [Display(Name ="Is Active")]
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string Gender { get; set; }
        [Display(Name="Employee Type")]
        public string EmployeeType { get; set; }
    }
}
