using EmployeesProject.Models;

namespace EmployeesProject.Interfaces
{
    public interface IClient
    {
        public ICollection<Client> GetAllClients();
    }
}
