using Microsoft.AspNetCore.Mvc;
using Repository;
using Service;
using System;
using System.Collections.Generic;


namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FacturaController : ControllerBase
    {
        private readonly FacturaRepository _facturaRepository;
        private readonly FacturaService _facturaService;

        public FacturaController(FacturaRepository facturaRepository, FacturaService facturaService)
        {
            _facturaRepository = facturaRepository;
            _facturaService = facturaService;
        }

        [HttpGet("{id}")]
        public ActionResult<Factura> Get(int id)
        {
            var factura = _facturaRepository.Get(id);
            if (factura == null)
            {
                return NotFound();
            }
            return factura;
        }

        [HttpPost]
        public IActionResult Post(Factura factura)
        {
            if (!_facturaService.ValidateFactura(factura))
            {
                return BadRequest("Factura no válida.");
            }

            _facturaRepository.Add(factura);
            return CreatedAtAction(nameof(Get), new { id = factura.Id }, factura);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Factura factura)
        {
            if (id != factura.Id)
            {
                return BadRequest();
            }

            if (!_facturaService.ValidateFactura(factura))
            {
                return BadRequest("Factura no válida.");
            }

            _facturaRepository.Update(factura);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var factura = _facturaRepository.Get(id);
            if (factura == null)
            {
                return NotFound();
            }

            _facturaRepository.Delete(id);
            return NoContent();
        }

        [HttpGet]
        public IEnumerable<Factura> GetAll()
        {
            return _facturaRepository.GetAll();
        }
    }
}
