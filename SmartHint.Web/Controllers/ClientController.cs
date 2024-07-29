using Microsoft.AspNetCore.Mvc;
using SmartHint.Application.DTOs.ClientDTO;
using SmartHint.Application.Interfaces;

namespace SmartHint.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _services;

        public ClientController(IClientService services)
        {
            _services = services;
        }

        [HttpPost("adicionarCliente")]
        public async Task<IActionResult> AddClient(CreateClientDTO clientDTO)
        {
            var client = await _services.AddClientAsync(clientDTO);
            return CreatedAtAction(nameof(GetClientById), new { id = client.Id }, clientDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(Guid id)
        {
            var client = await _services.GetClientByIdAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpGet("buscarTodos")]
        public async Task<IActionResult> GetAllClients(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _services.GetAllClientsAsync(pageNumber, pageSize);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(Guid id)
        {
            try
            {
                await _services.DeleteClientAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(Guid id, UpdateClientDTO clientDTO)
        {
            try
            {
                var updateClient = await _services.UpdateClientAsync(id, clientDTO);
                if (updateClient == null)
                {
                    return NotFound();
                }
                return Ok(updateClient);
                
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}
