using EmployeesProject.Interfaces;
using EmployeesProject.Models;

namespace EmployeesProject.Repository
{
    public class StateRepository : IState
    {
        private readonly employeeDatabaseContext _context;
        public StateRepository(employeeDatabaseContext context)
        {
            this._context = context;
        }

        public ICollection<State> GtAllStates()
        {
           return  _context.States.ToList();
        }
    }
}
