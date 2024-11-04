namespace LabSoft.Data.Negocio
{
    public interface IUserService
    {
        List<ApplicationUser> GetUsuarios();
        ApplicationUser? GetUsuarioById(string id);
        void AddUsuario(ApplicationUser user);
    }
}