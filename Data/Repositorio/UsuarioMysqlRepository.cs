
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LabSoft.Data.Repositorio
{
    public class UsuarioMysqlRepository : IUsuarioRepository
    {
        private readonly MyDbContext _context; //Todos los resposiotrios deben tener un contexto

        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public UsuarioMysqlRepository(MyDbContext context, UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void AddUsuario(Usuario usuario, string roleName)
        {
           
            var userExist = _userManager.FindByEmailAsync(usuario.Email).Result;

            if (userExist == null){
                userExist = new Usuario(){
                    Id =  Guid.NewGuid().ToString(),
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    TipoDocumento = usuario.TipoDocumento,
                    NumeroDocumento = usuario.NumeroDocumento,
                    Email = usuario.Email,
                    Telefono = usuario.Telefono,
                    FechaRegistro =  DateTime.Now,
                    Estado = "1",
                    Password = usuario.Password,
                    DireccionId = usuario.DireccionId,
                    PreferenciaId = usuario.PreferenciaId
                };

                var isCreated = _userManager.CreateAsync(userExist, usuario.PasswordHash).Result;
            }

            var roleExist = _roleManager.RoleExistsAsync(roleName).Result;

            if (!roleExist){
                var roleResult = _roleManager.CreateAsync(new IdentityRole(roleName)).Result;
            }

            var assignRoleResult = _userManager.AddToRoleAsync(userExist, roleName).Result;
        }
        public List<string> GetRolesUsuario(Usuario usuario)
        {
            return _userManager.GetRolesAsync(usuario).Result.ToList();
        }

        public void DeleteUsuario(string id)
        {
            var usuario = _context.Usuario.FirstOrDefault(usuarioId => usuarioId.Id.Equals(id));

            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
                _context.SaveChanges();
            }
        }
        public Usuario? GetUsuarioById(string id)
        {
            var usuario = _context.Usuario
            .Include(direccion => direccion.Direccion)
            .Include(preferencia => preferencia.Preferencia)
            .FirstOrDefault(usuarioId => usuarioId.Id.Equals(id));
            return usuario;
        }
        public Usuario? GetUsuarioByEmail(string email)
        {
            var usuario = _context.Usuario
            .Include(direccion => direccion.Direccion)
            .Include(preferencia => preferencia.Preferencia)
            .FirstOrDefault(usuarioEmail => usuarioEmail.Email.Equals(email));
            return usuario;
        }
        public List<Usuario> GetUsuarios()
        {
            var usuarios = _context.Usuario
            .Include(direccion => direccion.Direccion)
            .Include(preferencia => preferencia.Preferencia)
            .ToList();
            return usuarios;
        }
        public void UpdateUsuario(Usuario usuario)
        {
            var result = _context.Usuario.Update(usuario);
            _context.SaveChanges();
        }

        public bool ValidateUsuario(UsuarioLogin usuario)
        {
           var userFound = _userManager.FindByEmailAsync(usuario.Email).Result;

            if (userFound == null){
                return false;
            }

            var validatePassword = _userManager.CheckPasswordAsync(userFound, usuario.PasswordHash).Result;
            return validatePassword;
        }
    }
}
