using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IKEA.DAL.Common.Enums;

namespace IKEA.BLL.Dtos.Employees
{
    public class EmployeeToUpdateDto

    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Max Length should be 50 char")]
        [MinLength(5, ErrorMessage = "Min Length Should be 5 char")]
        public string Name { get; set; } = null!;

        [Range(22, 30)]
        public int? Age { get; set; }
        [RegularExpression(@"^[0-9]{1,3}-[A-Za-z]{5,10}-[A-Za-z]{4,10}-[A-Za-z]{5,10}$"
           , ErrorMessage = "Address must be like 123-street-City-Country")]
        public string? Address { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Salary { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Phone]
        [Display(Name = "Phone Number")]
        public string? PhoneNumber { get; set; }
        [Display(Name = "Hiring Date")]
        public DateTime HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }
    }
}
