using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Saref.Models.Client;
using Saref.Models.Dtos;
using Saref.Services.ClientServices;

namespace Saref.Controllers
{
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("[Controller]")]
    public class ClientController : Controller
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Client>>> GetClients()
        {
            return await _clientService.GetClients();
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateClient(string id, [FromBody] DtoClient dtoClient)
        {
            await _clientService.UpdateClientById(id, dtoClient);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClient(string id)
        {
            await _clientService.DeleteClientById(id);
            return Ok();
        }
    }
}
