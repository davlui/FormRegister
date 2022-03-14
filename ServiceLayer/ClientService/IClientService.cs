using ServiceLayer.Models;

namespace ServiceLayer.ClientService
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetAllClients();
        Task<ClientDetailsDto> GetClientById(int id);
        Task InsertClient(ClientDetailsDto client);
        Task UpdateClient(ClientDetailsDto client);
        Task DeleteClient(int id);
    }
}
