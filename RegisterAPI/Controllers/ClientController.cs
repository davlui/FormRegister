using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ClientService;
using ServiceLayer.Models;

namespace RegisterAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        public ClientController(IClientService clientService )
        {
            _clientService = clientService;
        }

        [HttpGet("{id}")]
        public IActionResult GetClient(int id)
        {
            var result = _clientService.GetClientById(id);
            if (result is not null)
            {
                return Ok(result);
            }

            return NotFound();
        }


        [HttpGet(Name = "GetAll")]
        public IActionResult GetAllClients()
        {
            var result = _clientService.GetAllClients();
            if (result is not null)
            {
                return Ok(result);
            }

            return NoContent();
        }

        [HttpPost]
        public IActionResult InsertClient([FromBody] ClientDetailsDto client)
        {
            _clientService.InsertClient(client);
            return Ok("New client created.");
        }


        [HttpPut]
        public IActionResult UpdateCLient(ClientDetailsDto client)
        {
            _clientService.UpdateClient(client);
            return Ok("Updated done");
        }

        [HttpDelete]
        public IActionResult DeleteClient(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }


            _clientService.DeleteClient(id);
            return NoContent();

        }

    }
}
