using FormRegisterWeb.Models;
using FormRegisterWeb.Repositories.Interfaces;

namespace FormRegisterWeb.Repositories
{
    public class ExternalRepository : IRepository
    {
        const string APIURL = "https://localhost:7083/api/";

        public async Task AddClient(Client client)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(APIURL);

                var response = await httpClient.PostAsJsonAsync("client", client);
                
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.StatusCode.ToString());
                } 
            }
        }

        public async Task DeleteClient(Client client)
        {
            await DeleteClientById(client.Id);
        }

        public async Task DeleteClientById(int id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(APIURL);

                var response = await httpClient.DeleteAsync($"client\\{id}");

                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception(response.StatusCode.ToString());
                }
            }
        }

        public  async Task<Client?> GetClientById(int id)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(APIURL);

                var response = await httpClient.GetAsync($"client\\{id}");


                if (!response.IsSuccessStatusCode) return null;

                var readClient = await response.Content.ReadAsAsync<Client>();

                return readClient;
            }
        }

        public async Task<List<Client>> GetClients()
        {
            List<Client> clients = null;

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(APIURL);

                var response = await httpClient.GetAsync("client");         

                if (response.IsSuccessStatusCode)
                {
                    var readTask = await response.Content.ReadAsAsync<List<Client>>();

                    clients = readTask;
                }
                else
                {

                    clients = new List<Client>();
                }

                return clients;
            }

        }

        public async Task<Client> UpdateClient(Client client)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(APIURL);

                var response = await httpClient.PutAsJsonAsync<Client>($"client", client);

                return client;
            }
        }
    }
}
