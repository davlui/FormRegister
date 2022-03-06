using Microsoft.AspNetCore.Mvc;

namespace FormRegisterWeb.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
