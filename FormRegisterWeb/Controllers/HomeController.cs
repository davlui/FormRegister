using FormRegisterWeb.Models;
using FormRegisterWeb.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FormRegisterWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IClientRepository _repository;

        public HomeController(ILogger<HomeController> logger, IClientRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Client client)
        {
            if (!ModelState.IsValid) return View(client);

            _repository.AddClient(client);
            return RedirectToAction("Sended");
        }

        public IActionResult Sended()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}