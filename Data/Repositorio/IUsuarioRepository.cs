namespace LabSoft.Data.Repositorio
{
    public interface IUsuarioRepository {
        List<Usuario> GetUsuarios();
        Usuario? GetUsuarioById(string id);
        Usuario? GetUsuarioByEmail(string email);
        void AddUsuario(Usuario usuario,string roleName);
        void UpdateUsuario(Usuario usuario);
        bool ValidateUsuario(UsuarioLogin usuario);
        void DeleteUsuario(string id);
        List<string> GetRolesUsuario(Usuario usuario);

    }
}