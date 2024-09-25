namespace LabSoft.Data.Negocio.Servicios
{
    public interface IUsuarioService {
        List<Usuario> GetUsuarios();
        Usuario? GetUsuarioById(string id);
        Usuario? GetUsuarioByEmail(string Email);
        void AddUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(string id);
        void UpdateUsuarioState(string id, string state);
        bool ValidateUsuario(string email, string password);
    }
}