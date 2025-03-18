namespace IKEA.PL.ViewModels.Department
{
    public class DepartmentViewModel
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;

        public string? Description { get; set; }

        public DateOnly CreationDate { get; set; }
    }
}
