
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
            _usuarioRepository.AddUsuario(usuario);
        }

        public void DeleteUsuario(string id)
        {
            _usuarioRepository.DeleteUsuario(id);
        }

        public Usuario? GetUsuarioById(string id)
        {
            return _usuarioRepository.GetUsuarioById(id);
        }

        public Usuario? GetUsuarioByEmail(string Email)
        {
            return _usuarioRepository.GetUsuarioByEmail(Email);
        }

        public List<Usuario> GetUsuarios()
        {
            return _usuarioRepository.GetUsuarios();
        }

        public void UpdateUsuario(Usuario usuario)
        {
            _usuarioRepository.UpdateUsuario(usuario);
        }

        public void UpdateUsuarioState(string id, string state)
        {
            _usuarioRepository.UpdateUsuarioState(id, state);
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
    }
}