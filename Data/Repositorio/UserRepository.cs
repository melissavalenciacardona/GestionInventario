
using Microsoft.AspNetCore.Identity;

namespace LabSoft.Data.Repositorio
{
    public class UserRepository : IUserRepository
    {
        private readonly MyDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository(MyDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager){
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void AddUsuario(ApplicationUser user, string roleName)
        {
            var userExist = _userManager.FindByEmailAsync(user.Email).Result;

            if (userExist == null){
                userExist = new ApplicationUser(){
                    Email = user.Email,
                    UserName = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                };

                var isCreated = _userManager.CreateAsync(userExist, user.PasswordHash).Result;
            }


            var roleExist = _roleManager.RoleExistsAsync(roleName).Result;

            if (!roleExist){
                var roleResult = _roleManager.CreateAsync(new IdentityRole(roleName)).Result;
            }

            var assignRoleResult = _userManager.AddToRoleAsync(userExist, roleName).Result;
        }

        public List<string> GetRolesUsuario(ApplicationUser user)
        {
            return _userManager.GetRolesAsync(user).Result.ToList();
        }

        public ApplicationUser? GetUsuarioByEmail(string email)
        {
            return _userManager.FindByEmailAsync(email).Result;
        }

        public List<ApplicationUser> GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public bool ValidarUsuario(ApplicationUser user)
        {
            var userFound = _userManager.FindByEmailAsync(user.Email).Result;

            if (userFound == null){
                return false;
            }

            var validatePassword = _userManager.CheckPasswordAsync(userFound, user.PasswordHash).Result;
            return validatePassword;
        }
    }
}