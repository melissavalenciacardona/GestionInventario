namespace LabSoft.Data.Negocio.Servicios
{
    public interface IUsuarioService {
        List<Usuario> GetUsuarios();
        Usuario? GetUsuarioById(string id);
        Usuario? GetUsuarioByEmail(string Email);
        bool ValidateUsuario(UsuarioLogin usuario);
        string GenerarToken(Usuario usuario);
        void AddUsuario(Usuario usuario, string roleName);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(string id);
    }
}