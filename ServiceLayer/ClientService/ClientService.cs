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

        public void DeleteClient(int id)
        {
            var client = _repository.Get(id);
            _repository.Remove(client);
            _repository.SaveChanges();
        }

        public IEnumerable<ClientDto> GetAllClients()
        {
            var clients = _repository.GetAll();

            return _mapper.Map<List<ClientDto>>(clients);
        }

        public ClientDetailsDto GetClientById(int id)
        {
            var client = _repository.Get(id);

            var _mappedClient = _mapper.Map<ClientDetailsDto>(client);

            return _mappedClient;
        }

        public void InsertClient(ClientDetailsDto client)
        {
            var _mappedClient = _mapper.Map<Client>(client);

            _repository.Insert(_mappedClient);
        }

        public void UpdateClient(ClientDetailsDto client)
        {
            var _mappedClient = _mapper.Map<Client>(client);

            _repository.Update(_mappedClient);
            _repository.SaveChanges();
        }
    }
}
