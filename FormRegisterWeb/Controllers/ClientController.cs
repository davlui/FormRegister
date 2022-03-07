using FormRegisterWeb.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FormRegisterWeb.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository _repository;

        public ClientController(IClientRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var clients = _repository.GetClients();

            return View(clients);
        }

        public IActionResult Detail(int id)
        {
            var client = _repository.GetClientById(id);

            return View(client);
        }
    }
}
