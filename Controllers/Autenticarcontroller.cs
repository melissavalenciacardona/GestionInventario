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
        private readonly IClienteService _clienteService; //Instancias

        public Autenticarcontroller(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        [HttpPost]
        public ActionResult Post( string email, string password)
        {
            var valido = _clienteService.ValidateCliente(email, password);
            if (valido)
            {
                var cliente = _clienteService.GetClienteByEmail(email);
                var mensaje = $"Bienvenid@ {cliente.Nombre} {cliente.Apellido}";
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
