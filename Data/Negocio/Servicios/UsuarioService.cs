
using LabSoft.Data.Repositorio;

namespace LabSoft.Data.Negocio.Servicios {
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        private readonly JwtConfig _jwtConfig;
        private readonly JwtToken _jwtToken;
        public UsuarioService(IUsuarioRepository usuarioRepository, JwtToken jwtToken){
            _usuarioRepository = usuarioRepository;
            _jwtToken = jwtToken;
        }

        public void AddUsuario(Usuario usuario, string roleName)
        {
            _usuarioRepository.AddUsuario(usuario,  roleName);
        }
        public string GenerarToken(Usuario usuario)
        {
            //Se obtienen los roles asignados al usuario en la tabla AspNetUserRoles
            var userRoles = _usuarioRepository.GetRolesUsuario(usuario);

            var jwtToken = _jwtToken.GenerarToken(usuario, userRoles);
            return jwtToken;
            
        }
        public Usuario? GetUsuarioById(string id)
        {
            return _usuarioRepository.GetUsuarioById(id);
        }

        public List<Usuario> GetUsuarios()
        {
            return _usuarioRepository.GetUsuarios();
        }

        public Usuario? GetUsuarioByEmail(string Email)
        {
            return _usuarioRepository.GetUsuarioByEmail(Email);
        }

        public void UpdateUsuario(Usuario usuario)
        {
            var usuarioUpd = _usuarioRepository.GetUsuarioById(usuario.Id);
            
            if(usuarioUpd != null){
                usuarioUpd.Nombre = usuario.Nombre;
                usuarioUpd.Apellido = usuario.Apellido;
                usuarioUpd.Email = usuario.Email;
                usuarioUpd.Telefono = usuario.Telefono;

                _usuarioRepository.UpdateUsuario(usuarioUpd);
            }
            
        }
        public bool ValidateUsuario(UsuarioLogin usuario)
        {
             var usuarioAutenticado = _usuarioRepository.ValidateUsuario(usuario);

            return usuarioAutenticado;
        }

        public void DeleteUsuario(string id)
        {
            _usuarioRepository.DeleteUsuario(id);
        }
    }
}