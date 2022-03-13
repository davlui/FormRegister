using ServiceLayer.Models;

namespace ServiceLayer.ClientService
{
    public interface IClientService
    {
        IEnumerable<ClientDto> GetAllClients();
        ClientDetailsDto GetClientById(int id);
        void InsertClient(ClientDetailsDto client);
        void UpdateClient(ClientDetailsDto client);
        void DeleteClient(int id);
    }
}
