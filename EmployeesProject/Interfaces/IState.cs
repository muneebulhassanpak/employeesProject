using EmployeesProject.Models;

namespace EmployeesProject.Interfaces
{
    public interface IState
    {
        public ICollection<State> GetAllStates();

        public State GetStateById(int id);

        public string GetStateNameById(int id);
    }
}
