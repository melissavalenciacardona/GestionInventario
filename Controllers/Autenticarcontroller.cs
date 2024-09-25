using Microsoft.AspNetCore.Mvc;
using LabSoft.Data.Negocio.Servicios;
using System.Collections.Generic;
using LabSoft.Data;

namespace LabSoft.Controllers
{
    [ApiController]
    [Route("verification/[controller]")]
    public class Autenticarcontroller : ControllerBase
    {
        private readonly IUsuarioService _usuarioService; //Instancias

        public Autenticarcontroller(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public ActionResult Post([FromBody] UsuarioLogin usuarioLogin)
        {
            var valido = _usuarioService.ValidateUsuario(usuarioLogin.Email, usuarioLogin.Password);
            if (valido)
            {
                var usuario = _usuarioService.GetUsuarioByEmail(usuarioLogin.Email);
                var mensaje = $"Bienvenid@ {usuario.Nombre} {usuario.Apellido}";
                var response = new { Autenticacion = valido, 
                                jwt = Guid.NewGuid().ToString(), 
                                mensaje = mensaje};
                return Ok(response);
            }
            else
            {
                var response = new { Autenticacion = valido, 
                                jwt = "", 
                                mensaje = "Usuario o contraseña incorrectos"};
                return Unauthorized(response);
            }
        }
    }
}
