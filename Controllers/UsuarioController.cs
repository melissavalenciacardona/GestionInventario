using AutoMapper;
using LabSoft.Data;
using LabSoft.Data.Negocio.Servicios;
using LabSoft.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LabSoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper){
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        
        public ActionResult<List<UsuarioResponseDTO>> Get(){
            try {
                var usuarios = _usuarioService.GetUsuarios();
                var usuariosResponse = _mapper.Map<List<Usuario>, List<UsuarioResponseDTO>>(usuarios);
                return Ok(usuariosResponse);

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
        public ActionResult<Usuario> Get(string id){
            try
            {
                var usuario = _usuarioService.GetUsuarioById(id);

                if(usuario == null)
                {
                    return NotFound();
                }
                return Ok(usuario);
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
        public ActionResult Post([FromBody] UsuarioRequestDTO usuario) 
        {
            try
            {
                if(usuario == null){
                    return  BadRequest("El usuario no puede ser nulo");
                }

                var usuarioMapeado = _mapper.Map<UsuarioRequestDTO, Usuario>(usuario);

                _usuarioService.AddUsuario(usuarioMapeado,usuario.RoleName);
                return CreatedAtAction(nameof(Get), new {id = usuarioMapeado.Id}, usuario);
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
        public ActionResult Put(string id, [FromBody] Usuario usuario)
        {
            if(usuario == null || usuario.Id != id) {
                return BadRequest();
            }

            var usuarioExistente = _usuarioService.GetUsuarioById(id);

            if(usuarioExistente == null){
                return NotFound();
            }

            _usuarioService.UpdateUsuario(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id){
            var usuario = _usuarioService.GetUsuarioById(id);

            if(usuario == null){
                return NotFound();
            }

            _usuarioService.DeleteUsuario(id);
            return NoContent();
        }
    }
}