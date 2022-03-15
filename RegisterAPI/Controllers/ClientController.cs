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
        public async Task<IActionResult> GetClient(int id)
        {
            var result = await _clientService.GetClientById(id);
            
            if (result is not null)
            {
                return Ok(result);
            }

            return NotFound();
        }


        [HttpGet(Name = "GetAll")]
        public async Task<IActionResult> GetAllClients()
        {
            var result = await _clientService.GetAllClients();
            if (result is not null)
            {
                if (result.Count() == 0)
                {
                    return NoContent();
                }

                return Ok(result);
            }

            return BadRequest("Service Failed");
        }

        [HttpPost]
        public async Task<IActionResult> InsertClient([FromBody] ClientDetailsDto client)
        {
            await _clientService.InsertClient(client);
            return Ok("New client created.");
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCLient([FromBody] ClientDetailsDto client)
        {
            await _clientService.UpdateClient(client);
            return Ok("Updated done");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            await _clientService.DeleteClient(id);
            return NoContent();

        }

    }
}
