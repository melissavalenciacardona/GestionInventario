using Microsoft.AspNetCore.Mvc;
using LabSoft.Data.Negocio.Servicios;
using System.Collections.Generic;
using LabSoft.Data;

namespace LabSoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService; //Instancias

        public UsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult<List<Usuario>> Get()
        {
            var usuarios = _usuarioService.GetUsuarios();
            return Ok(usuarios); //returno ok() devulve 200
        }

        [HttpGet("id/{id}")]
        public ActionResult<Usuario> Get(string id)
        {
            var usuario = _usuarioService.GetUsuarioById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpGet("email/{email}")]
        public ActionResult<Usuario> GetByEmail(string email)
        {
            var usuario = _usuarioService.GetUsuarioByEmail(email);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Usuario usuario)
        {
            if (usuario == null)
            {
                return BadRequest();
            }

            _usuarioService.AddUsuario(usuario);
            return CreatedAtAction(nameof(Get), new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Usuario usuario)
        {
            if (usuario == null || usuario.Id != id)
            {
                return BadRequest();
            }

            var existingUsuario = _usuarioService.GetUsuarioById(id);
            if (existingUsuario == null)
            {
                return NotFound();
            }

            _usuarioService.UpdateUsuario(usuario);
            _usuarioService.UpdateUsuarioState(id, usuario.Estado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var usuario = _usuarioService.GetUsuarioById(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _usuarioService.DeleteUsuario(id);
            return NoContent();
        }
    }
}
