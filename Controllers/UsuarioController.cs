using AutoMapper;
using LabSoft.Data;
using LabSoft.Data.Negocio;
using LabSoft.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LabSoft.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UsuarioController(IUserService userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult RegistrarUsuario([FromBody] UserRequestDTO request)
        {
            try
            {
                if (request == null)
                {
                    return BadRequest("Usuario no puede ser null");
                }


                var user = _mapper.Map<UserRequestDTO, ApplicationUser>(request);
                _userService.AddUsuario(user, request.RoleName);

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500,
                    new
                    {
                        mensaje = "Ocurrio un error interno en el servidor",
                        detalles = ex.Message
                    }
                );
            }
        }
    }
}
