
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LabSoft.Data.Negocio;
using LabSoft.Data.Repositorio;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;


namespace LabSoft.Data.Negocio.Servicios
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtConfig _jwtConfig;
        private readonly JwtToken _jwtToken;

        public UserService(IUserRepository userRepository, JwtToken jwtToken){
            _userRepository = userRepository;
            _jwtToken = jwtToken;
        }

        public void AddUsuario(ApplicationUser user, string roleName)
        {
            _userRepository.AddUsuario(user, roleName);
        }

        public string GenerarToken(ApplicationUser user)
        {
            //Se obtienen los roles asignados al usuario en la tabla AspNetUserRoles
            var userRoles = _userRepository.GetRolesUsuario(user);

            var jwtToken = _jwtToken.GenerarToken(user, userRoles);
            return jwtToken;
            
        }

        public ApplicationUser? GetUsuarioByEmail(string email)
        {
            return _userRepository.GetUsuarioByEmail(email);
        }

        public List<ApplicationUser> GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public bool ValidarLogin(ApplicationUser user)
        {
            var usuarioAutenticado = _userRepository.ValidarUsuario(user);

            return usuarioAutenticado;
        }
    }
}