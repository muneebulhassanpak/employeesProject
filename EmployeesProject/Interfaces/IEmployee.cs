using EmployeesProject.Dto;
using EmployeesProject.Models;

namespace EmployeesProject.Interfaces
{
    public interface IEmployee
    {
        public ICollection<Employee> GetAllEmployees(int pageNumber,int pageSize);
        public int CountTotalEmployees();

        public Employee GetEmployeeById(int employeeId);

        public Task<Employee> CreateNewEmployee(NewEmployeeDto newEmployeeDto);

        public bool Save();
    }
}
