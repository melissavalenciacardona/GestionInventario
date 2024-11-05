namespace LabSoft.Data.Repositorio
{
    public interface IUsuarioRepository {
        List<Usuario> GetUsuarios();
        Usuario? GetUsuarioById(string id);
        Usuario? GetUsuarioByEmail(string email);
        void AddUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(string id);
    }
}