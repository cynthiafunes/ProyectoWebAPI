using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly ClienteService _clienteService;

        public ClienteController(ClienteRepository clienteRepository, ClienteService clienteService)
        {
            _clienteRepository = clienteRepository;
            _clienteService = clienteService;
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(int id)
        {
            var cliente = _clienteRepository.Get(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return cliente;
        }

        [HttpPost]
        public IActionResult Post(Cliente cliente)
        {
            if (!_clienteService.ValidateCliente(cliente))
            {
                return BadRequest("Cliente no válido.");
            }

            _clienteRepository.Add(cliente);
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            if (!_clienteService.ValidateCliente(cliente))
            {
                return BadRequest("Cliente no válido.");
            }

            _clienteRepository.Update(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var cliente = _clienteRepository.Get(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _clienteRepository.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public IEnumerable<Cliente> GetAll()
        {
            return _clienteRepository.GetAll();
        }
    }
}
