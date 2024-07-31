using EmployeesProject.Interfaces;
using EmployeesProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeesProject.Repository
{
    public class EmployeeRepository : IEmployee
    {
        private readonly employeeDatabaseContext _context;

        public EmployeeRepository(employeeDatabaseContext context)
        {
            _context = context;
        }

        public ICollection<Employee> GetAllEmployees(int pageNumber, int pageSize)
        {
          
            int toBeMissed = pageSize * (pageNumber - 1);

            
            var employees = _context.Employees
                                    .OrderBy(e => e.Id) 
                                    .Skip(toBeMissed)
                                    .Take(pageSize)
                                    .ToList();

            return employees;
        }
        public int CountTotalEmployees()
        {
            return _context.Employees.Count();
        }

        public Employee GetEmployeeById(int employeeId)
        {
            var employee = _context.Employees.Where(emp=>emp.Id == employeeId).FirstOrDefault();
            return employee;
        }
    }
}
