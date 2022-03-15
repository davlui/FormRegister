using AutoMapper;
using DomainLayer.Models;
using RepositoryLayer.Repository;
using ServiceLayer.Models;

namespace ServiceLayer.ClientService
{
    public class ClientService : IClientService
    {

        private IRepository<Client> _repository;
        private readonly IMapper _mapper;

        public ClientService(IRepository<Client> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task DeleteClient(int id)
        {
            var client = await _repository.Get(id);
            await _repository.Remove(client);
            await _repository.SaveChanges();
        }

        public async Task<IEnumerable<ClientDto>> GetAllClients()
        {
            var clients = await _repository.GetAll();

            return _mapper.Map<List<ClientDto>>(clients);
        }

        public async Task<ClientDetailsDto> GetClientById(int id)
        {
            var client = await _repository.Get(id);

            var _mappedClient = _mapper.Map<ClientDetailsDto>(client);

            return _mappedClient;
        }

        public async Task InsertClient(ClientDetailsDto client)
        {
            var _mappedClient = _mapper.Map<Client>(client);

            _mappedClient.CreatedDate = DateTime.Now;
            _mappedClient.ModifiedDate = DateTime.Now;

            await _repository.Insert(_mappedClient);
        }

        public async Task UpdateClient(ClientDetailsDto client)
        {
            var _mappedClient = _mapper.Map<Client>(client);

            _mappedClient.CreatedDate = DateTime.Now;
            _mappedClient.ModifiedDate = DateTime.Now;


            await _repository.Update(_mappedClient);
            await _repository.SaveChanges();
        }
    }
}
