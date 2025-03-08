using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Dtos.Departments
{
    public class CreateDepartmentDto
    {



        [Required(ErrorMessage ="Name is Requried , Please Enter Department Name")]
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;

        public string? Description { get; set; }

        [Display(Name="Creation Date")]
        public DateOnly CreationDate { get; set; }
    }
}
