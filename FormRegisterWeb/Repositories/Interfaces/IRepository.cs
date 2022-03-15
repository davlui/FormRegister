using FormRegisterWeb.Models;

namespace FormRegisterWeb.Repositories.Interfaces
{
    public interface IRepository
    {
        Task AddClient(Client client);
        Task<List<Client>>GetClients();
        Task<Client?> GetClientById(int id);
        Task<Client> UpdateClient(Client client);
        Task DeleteClientById(int id);
        Task DeleteClient(Client client);
    }
}
