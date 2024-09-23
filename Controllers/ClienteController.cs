using Microsoft.AspNetCore.Mvc;
using LabSoft.Data.Negocio.Servicios;
using System.Collections.Generic;
using LabSoft.Data;

namespace LabSoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteService _clienteService; //Instancias

        public ClientesController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpGet]
        public ActionResult<List<Cliente>> Get()
        {
            var clientes = _clienteService.GetClientes();
            return Ok(clientes); //returno ok() devulve 200
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(string id)
        {
            var cliente = _clienteService.GetClienteById(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return Ok(cliente);
        }

        

        [HttpPost]
        public ActionResult Post([FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }

            _clienteService.AddCliente(cliente);
            return CreatedAtAction(nameof(Get), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Cliente cliente)
        {
            if (cliente == null || cliente.Id != id)
            {
                return BadRequest();
            }

            var existingCliente = _clienteService.GetClienteById(id);
            if (existingCliente == null)
            {
                return NotFound();
            }

            _clienteService.UpdateCliente(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var cliente = _clienteService.GetClienteById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _clienteService.DeleteCliente(id);
            return NoContent();
        }
    }
}
