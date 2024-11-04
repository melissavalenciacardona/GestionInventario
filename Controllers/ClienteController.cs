using AutoMapper;
using LabSoft.Data;
using LabSoft.Data.Negocio.Servicios;
using LabSoft.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LabSoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;
        private readonly IMapper _mapper;

        public ClienteController(IClienteService clienteService, IMapper mapper){
            _clienteService = clienteService;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ClienteResponseDTO>> Get(){
            try {
                var clientes = _clienteService.GetClientes();
                var clientesResponse = _mapper.Map<List<Cliente>, List<ClienteResponseDTO>>(clientes);
                return Ok(clientesResponse);

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return BadRequest(ex.Message);
                return StatusCode(500, 
                    new {
                            mensaje = "Ocurrio un error interno en el servidor", 
                            detalles = ex.Message
                        }
                );
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Cliente> Get(string id){
            try
            {
                var cliente = _clienteService.GetClienteById(id);

                if(cliente == null)
                {
                    return NotFound();
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return BadRequest(ex.Message);
                return StatusCode(500, 
                    new {
                            mensaje = "Ocurrio un error interno en el servidor", 
                            detalles = ex.Message
                        }
                );
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody] ClienteRequestDTO cliente) 
        {
            try
            {
                if(cliente == null){
                    return  BadRequest("El cliente no puede ser nulo");
                }

                var clienteMapeado = _mapper.Map<ClienteRequestDTO, Cliente>(cliente);

                _clienteService.AddCliente(clienteMapeado);
                return CreatedAtAction(nameof(Get), new {id = clienteMapeado.Id}, cliente);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return BadRequest(ex.Message);
                return StatusCode(500, 
                    new {
                            mensaje = "Ocurrio un error interno en el servidor", 
                            detalles = ex.Message
                        }
                );
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Cliente cliente)
        {
            if(cliente == null || cliente.Id != id) {
                return BadRequest();
            }

            var clienteExistente = _clienteService.GetClienteById(id);

            if(clienteExistente == null){
                return NotFound();
            }

            _clienteService.UpdateCliente(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id){
            var cliente = _clienteService.GetClienteById(id);

            if(cliente == null){
                return NotFound();
            }

            _clienteService.DeleteCliente(id);
            return NoContent();
        }
    }
}