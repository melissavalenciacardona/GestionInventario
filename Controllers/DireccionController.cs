using LabSoft.Data;
using LabSoft.Data.Negocio.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace LabSoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DireccionController : ControllerBase
    {
        private readonly IDireccionService _direccionService;

        public DireccionController(IDireccionService direccionService)
        {
            _direccionService = direccionService;
        }

        [HttpGet("{id}")]
        public ActionResult<Direccion> Get(string id){
            try
            {
                var Direccion = _direccionService.GetDireccionById(id);

                if(Direccion == null)
                {
                    return NotFound();
                }
                return Ok(Direccion);
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
        public ActionResult Post([FromBody] Direccion direccion)
        {
            try
            {
                if (direccion == null)
                {
                    return BadRequest("La Direccion no puede ser nula");
                }
                _direccionService.AddDireccion(direccion);
                return CreatedAtAction(nameof(Get), new { id = direccion.Id }, direccion);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //return BadRequest(ex.Message);
                return StatusCode(500,
                    new
                    {
                        mensaje = "Ocurrio un error interno en el servidor",
                        detalles = ex.Message
                    }
                );
            }
        }

        [HttpGet]
        public ActionResult<List<Direccion>> Get(){
            try {
                var direcciones = _direccionService.GetDireccion();
                return Ok(direcciones);

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