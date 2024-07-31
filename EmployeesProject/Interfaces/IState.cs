using EmployeesProject.Models;

namespace EmployeesProject.Interfaces
{
    public interface IState
    {
        public ICollection<State> GtAllStates();
    }
}
