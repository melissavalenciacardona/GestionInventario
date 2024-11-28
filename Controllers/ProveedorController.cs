using AutoMapper;
using LabSoft.Data;
using LabSoft.Data.Negocio.Servicios;
using LabSoft.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LabSoft.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;
        private readonly IMapper _mapper;

        public ProveedorController(IProveedorService proveedorService, IMapper mapper){
            _proveedorService = proveedorService;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "ADMIN")]
        public ActionResult<List<ProveedorResponseDTO>> Get(){
            try {
                var proveedors = _proveedorService.GetProveedores();
                var proveedorsResponse = _mapper.Map<List<Proveedor>, List<ProveedorResponseDTO>>(proveedors);
                return Ok(proveedorsResponse);

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
        [Authorize(Roles = "ADMIN,AUXILIAR")]
        public ActionResult<Proveedor> Get(string id){
            try
            {
                var proveedor = _proveedorService.GetProveedorById(id);

                if(proveedor == null)
                {
                    return NotFound();
                }
                return Ok(proveedor);
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
        [Authorize(Roles = "ADMIN,AUXILIAR")]
        public ActionResult Post([FromBody] ProveedorRequestDTO proveedor) 
        {
            try
            {
                if(proveedor == null){
                    return  BadRequest("El proveedor no puede ser nulo");
                }

                var proveedorMapeado = _mapper.Map<ProveedorRequestDTO, Proveedor>(proveedor);

                _proveedorService.AddProveedor(proveedorMapeado);
                return CreatedAtAction(nameof(Get), new {id = proveedorMapeado.Id}, proveedor);
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
        [Authorize(Roles = "ADMIN")]
        public ActionResult Put(string id, [FromBody] Proveedor proveedor)
        {
            if(proveedor == null || proveedor.Id != id) {
                return BadRequest();
            }

            var proveedorExistente = _proveedorService.GetProveedorById(id);

            if(proveedorExistente == null){
                return NotFound();
            }

            _proveedorService.UpdateProveedor(proveedor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult Delete(string id){
            var proveedor = _proveedorService.GetProveedorById(id);

            if(proveedor == null){
                return NotFound();
            }

            _proveedorService.DeleteProveedor(id);
            return NoContent();
        }
    }
}