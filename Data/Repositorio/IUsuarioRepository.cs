namespace LabSoft.Data.Repositorio
{
    public interface IUsuarioRepository {
        List<Usuario> GetUsuarios();
        Usuario? GetUsuarioById(string id);
        void AddUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(string id);
    }
}