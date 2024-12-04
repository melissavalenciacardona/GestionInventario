namespace LabSoft.Data.Negocio
{
    public interface IUserService
    {
        List<ApplicationUser> GetUsuarios();
        ApplicationUser? GetUsuarioByEmail(string email);
        void AddUsuario(ApplicationUser user, string roleName);
        bool ValidarLogin(ApplicationUser user);
        string GenerarToken(ApplicationUser user);
    }
}