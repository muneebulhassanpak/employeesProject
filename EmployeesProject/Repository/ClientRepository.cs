using EmployeesProject.Interfaces;
using EmployeesProject.Models;

namespace EmployeesProject.Repository
{
    public class ClientRepository: IClient
    {
        private readonly employeeDatabaseContext _context;
        public ClientRepository(employeeDatabaseContext context)
        {
            this._context = context;
        }

        public ICollection<Client> GetAllClients()
        {
            return _context.Clients.ToList();
        }

        public Client GetClientById(int clientId) {
            return _context.Clients.Where(c=>c.Id == clientId).FirstOrDefault();
        }
    }
}
