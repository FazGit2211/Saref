using Microsoft.AspNetCore.Mvc;
using Saref.Models.Client;
using Saref.Services.ClientServices;

namespace Saref.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ClientController : Controller
    {
        private readonly ClientService _clientService;

        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost]
        [Route("{userId}")]
        public async Task<ActionResult<Client>> PostClient([FromBody] Client paramClient, int userId)
        {
            try
            {
                Client clientCreated = await _clientService.CreateClient(paramClient, userId);
                if (clientCreated == null)
                {
                    return BadRequest();
                }

                return Ok(clientCreated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
