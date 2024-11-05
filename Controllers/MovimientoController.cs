using LabSoft.Data;
using LabSoft.Data.Negocio.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace LabSoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovimientoController : ControllerBase
    {
        private readonly IMovimientoService _movimientoService;

        public MovimientoController(IMovimientoService movimientoService)
        {
            _movimientoService = movimientoService;
        }

        [HttpGet]
        public ActionResult<List<Movimiento>> Get(){
            try {
                var movimientos = _movimientoService.GetMovimiento();
                return Ok(movimientos);

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

        [HttpGet("{ProductoId}")]
        public ActionResult<List<Movimiento>> Get(string ProductoId){
            try
            {
                var movimiento = _movimientoService.GetMovimientoById(ProductoId);

                if(movimiento == null)
                {
                    return NotFound();
                }
                return Ok(movimiento);
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
    }
}