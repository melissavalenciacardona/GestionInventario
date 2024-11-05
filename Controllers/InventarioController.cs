using LabSoft.Data;
using LabSoft.Data.Negocio.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace LabSoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InventarioController : ControllerBase
    {
        private readonly IInventarioService _inventarioService;

        public InventarioController(IInventarioService inventarioService)
        {
            _inventarioService = inventarioService;
        }

        [HttpGet("Buscar/{criterio}&{valor}")]
        public ActionResult<List<Inventario>> Get(string criterio, string valor){
            try {
                var inventarios = _inventarioService.Buscar(criterio, valor);
                return Ok(inventarios);

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
        
        [HttpPost("Disminuir/{ProductoId}&{cantidad}&{motivo}")]
        public ActionResult<Inventario> Disminuir(string ProductoId, int cantidad, string motivo){
            try {
                var inventarioActualizado = _inventarioService.Disminuir(ProductoId, cantidad, motivo);
                return Ok(inventarioActualizado);

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
        [HttpPost("Adicionar/{ProductoId}&{cantidad}&{motivo}")]
        public ActionResult<Inventario> Adicionar(string ProductoId, int cantidad, string motivo){
            try {
                var inventarioActualizado = _inventarioService.Adicionar(ProductoId, cantidad, motivo);
                return Ok(inventarioActualizado);

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
    }
}