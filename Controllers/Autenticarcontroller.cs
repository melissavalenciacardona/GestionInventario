using Microsoft.AspNetCore.Mvc;
using LabSoft.Data.Negocio.Servicios;
using System.Collections.Generic;
using LabSoft.Data.Negocio;
using AutoMapper;
using LabSoft.Data;

namespace LabSoft.Controllers
{
    [ApiController]
    [Route("verification/[controller]")]
    public class Autenticarcontroller : ControllerBase
    {
        private readonly IUsuarioService _usuarioService; //Instancias
        private readonly IMapper _mapper;
        public Autenticarcontroller(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public ActionResult Post([FromBody] UsuarioLogin usuarioLogin)
        {
            var valido = _usuarioService.ValidateUsuario(usuarioLogin);
            if (valido)
            {
                var usuario = _usuarioService.GetUsuarioByEmail(usuarioLogin.Email);
                var token = _usuarioService.GenerarToken(usuario);
                return Ok(new {Token = token});            }
            else
            {
               return BadRequest(new
                {
                    Result = false,
                    Errors = new List<string>() { "Password invalido!" }
                });
            }
        }
    }
}