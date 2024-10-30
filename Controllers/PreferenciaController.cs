using LabSoft.Data;
using LabSoft.Data.Negocio.Servicios;
using Microsoft.AspNetCore.Mvc;

namespace LabSoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PreferenciaController : ControllerBase
    {
        private readonly IPreferenciaService _preferenciaService;

        public PreferenciaController(IPreferenciaService preferenciaService)
        {
            _preferenciaService = preferenciaService;
        }

        [HttpGet("{id}")]
        public ActionResult<Preferencia> Get(string id){
            try
            {
                var preferencia = _preferenciaService.GetPreferenciaById(id);

                if(preferencia == null)
                {
                    return NotFound();
                }
                return Ok(preferencia);
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
        public ActionResult Post([FromBody] Preferencia preferencia)
        {
            try
            {
                if (preferencia == null)
                {
                    return BadRequest("La Preferencia no puede ser nula");
                }
                _preferenciaService.AddPreferencia(preferencia);
                return CreatedAtAction(nameof(Get), new { id = preferencia.Id }, preferencia);
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
        public ActionResult<List<Preferencia>> Get(){
            try {
                var preferencias = _preferenciaService.GetPreferencia();
                return Ok(preferencias);

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