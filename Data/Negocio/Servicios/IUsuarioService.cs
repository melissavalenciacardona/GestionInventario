namespace LabSoft.Data.Negocio.Servicios
{
    public interface IUsuarioService {
        List<Usuario> GetUsuarios();
        Usuario? GetUsuarioById(string id);
        void AddUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(string id);
    }
}