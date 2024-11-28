using Microsoft.AspNetCore.Mvc;
using LabSoft.Data.Negocio.Servicios;
using System.Collections.Generic;
using LabSoft.Data.Negocio;
using AutoMapper;
using LabSoft.Data;

namespace LabSoft.Controllers
{
    [ApiController]
    [Route("Alertas")]
    public class Alertascontroller : ControllerBase
    {
        private readonly IInventarioService _inventarioService; //Instancias
        public Alertascontroller(IInventarioService inventarioService)
        {
            _inventarioService = inventarioService;
        }

        [HttpGet()]
        public ActionResult Get()
        {
            var alertas = _inventarioService.GetAlertas();
            return Ok(alertas);
            
        }
    }
}