using FormRegisterWeb.Models;

namespace FormRegisterWeb.Repositories.Interfaces
{
    public interface IClientRepository
    {
        List<Client> AddClient(Client client);
        List<Client> GetClients();
        Client? GetClientById(int id);
        Client UpdateClient(Client client);
        void DeleteClientById(int id);
        void DeleteClient(Client client);
    }
}
