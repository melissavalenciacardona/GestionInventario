using Microsoft.AspNetCore.Mvc;
using LabSoft.Data.Negocio.Servicios;
using System.Collections.Generic;
using LabSoft.Data.Negocio;
using AutoMapper;
using LabSoft.Data;

namespace LabSoft.Controllers
{
    [ApiController]
    [Route("Reporte")]
    public class Reportecontroller : ControllerBase
    {
        private readonly IInventarioService _inventarioService; //Instancias
        public Reportecontroller(IInventarioService inventarioService)
        {
            _inventarioService = inventarioService;
        }

        [HttpGet("csv")]
        public IActionResult GetCsv(string criterio, string valor)
        {
            var reporte = _inventarioService.GetReporte(criterio, valor);
            string csv = "";
            foreach (var key in reporte[0].Keys)
            {
                csv += key + ";";
            }
            csv = csv.Substring(0, csv.Length - 1) + "\n";
            foreach (var item in reporte)
            {
                foreach (var value in item.Values)
                {
                    csv += value + ";";
                }
                csv = csv.Substring(0, csv.Length - 1) + "\n";
            }

            var bytes = System.Text.Encoding.UTF8.GetBytes(csv);
            var result = new FileContentResult(bytes, "text/csv")
            {
                FileDownloadName = "reporte.csv"
            };

            return result;
        }
    }
}