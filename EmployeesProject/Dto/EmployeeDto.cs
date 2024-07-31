using EmployeesProject.Models;

namespace EmployeesProject.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public virtual Client Client { get; set; } = null!;

        public string Yearsofexperience { get; set; } = null!;

        public decimal Rate { get; set; }
        public bool RateFlag { get; set; }
        public string? Gender { get; set; }
    }
}
