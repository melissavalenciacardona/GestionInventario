
using LabSoft.Data.Repositorio;

namespace LabSoft.Data.Negocio.Servicios {
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository){
            this._usuarioRepository = usuarioRepository;
        }

        public void AddUsuario(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid().ToString();
            usuario.Estado = "1";
            usuario.FechaRegistro = DateTime.Now;
            
            _usuarioRepository.AddUsuario(usuario);
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
        public bool ValidateUsuario(string email, string password)
        {
            var usuario = _usuarioRepository.GetUsuarioByEmail(email);
            if (usuario != null)
            {
                return usuario.Password == password;
            }
            return false;
        }

        public void DeleteUsuario(string id)
        {
            _usuarioRepository.DeleteUsuario(id);
        }
    }
}