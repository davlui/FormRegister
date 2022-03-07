using FormRegisterWeb.Models;
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

        [HttpGet]
        public IActionResult Index()
        {
            var clients = _repository.GetClients();

            return View(clients);
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            var client = _repository.GetClientById(id);

            return View(client);
        }


        // GET
        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var client = _repository.GetClientById(id.Value);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }


        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Client obj)
        {
            if (ModelState.IsValid)
            {
                _repository.UpdateClient(obj);
                return RedirectToAction("Index");
            }

            return View(obj);
        }

    }
}
