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

        public ICollection<State> GetAllStates()
        {
           return  _context.States.ToList();
        }

        public State GetStateById(int stateId)
        {
            return _context.States.Where(c => c.Id == stateId).FirstOrDefault();
        }
        public string GetStateNameById(int id)
        {
            return _context.States.Where(c => c.Id == id).FirstOrDefault().Name;

        }
    }
}
