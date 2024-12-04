namespace LabSoft.Data.Repositorio
{
    public interface IUserRepository
    {
        List<ApplicationUser> GetUsuarios();
        ApplicationUser? GetUsuarioByEmail(string email);
        void AddUsuario(ApplicationUser user, string roleName);
        bool ValidarUsuario(ApplicationUser user);
        List<string> GetRolesUsuario(ApplicationUser user);
    }
}