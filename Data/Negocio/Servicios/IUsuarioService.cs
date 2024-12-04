namespace LabSoft.Data.Negocio.Servicios
{
    public interface IUsuarioService {
        List<Usuario> GetUsuarios();
        Usuario? GetUsuarioById(string id);
        Usuario? GetUsuarioByEmail(string Email);
        bool ValidateUsuario(string email, string password);
        void AddUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(string id);
    }
}