namespace LabSoft.Data.Repositorio
{
    public interface IUserRepository
    {
        List<ApplicationUser> GetUsuarios();
        ApplicationUser? GetUsuarioById(string id);
        void AddUsuario(ApplicationUser user);
    }
}