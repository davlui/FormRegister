using FormRegisterWeb.Models;
using FormRegisterWeb.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FormRegisterWeb.Controllers
{
    public class ClientController : Controller
    {
        private readonly IRepository _repository;

        public ClientController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clients = await _repository.GetClients();

            return View(clients);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            var client = await _repository.GetClientById(id);

            return View(client);
        }


        // GET
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }

            var client = await _repository.GetClientById(id.Value);

            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }


        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Client obj)
        {
            if (ModelState.IsValid)
            {
                await _repository.UpdateClient(obj);
                return RedirectToAction("Index");
            }

            return View(obj);
        }


        // GET
        [HttpGet]
        public async Task<IActionResult> Delete2(int id)
        {
            if (id == 0) return NotFound();

            var client = await _repository.GetClientById(id);

            if (client == null) return NotFound();

            return View(client);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteClient(int id)
        {
            if(id == 0) return NotFound();
                        
            await _repository.DeleteClientById(id);
            
            return RedirectToAction("Index");
        }

    }
}
