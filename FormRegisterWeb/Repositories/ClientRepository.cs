using FormRegisterWeb.Data;
using FormRegisterWeb.Models;
using FormRegisterWeb.Repositories.Interfaces;

namespace FormRegisterWeb.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly AppDbContext _db;
        public ClientRepository(AppDbContext db)
        {
            _db = db;
        }

        // Add new client
        public List<Client> AddClient(Client client)
        {
            _db.Clients.Add(client);
            _db.SaveChanges();

            return _db.Clients.ToList();
        }

        // Delete a client by a object
        public void DeleteClient(Client client)
        {
            _db.Clients.Remove(client);
            _db.SaveChanges();
        }

        // Delete a client by id
        public void DeleteClientById(int id)
        {
            var client = _db.Clients.Find(id);
            DeleteClient(client);
        }

        // Search a client by id
        public Client? GetClientById(int id)
        {
            var client = _db.Clients.Find(id);
            if (client == null)
                return null;

            return client;
        }


        // Get all clients
        public List<Client> GetClients()
        {
            return _db.Clients.ToList();
        }


        // Updates a Client
        public Client UpdateClient(Client client)
        {
            var result = _db.Clients.Update(client);
            _db.SaveChanges();
            return result.Entity;
        }
    }
}
