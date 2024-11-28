
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace LabSoft.Data.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private static readonly List<Usuario> usuarios = new List<Usuario>();
        private readonly MyDbContext _context; //Todos los resposiotrios deben tener un contexto
        private readonly UserManager<Usuario> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UsuarioRepository(MyDbContext context, UserManager<Usuario> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        static UsuarioRepository(){
            for (int i = 0; i < 5; i++)
            {
                var nombre = DataGenerator.GenerateRandomNombre();
                usuarios.Add(new Usuario
                {
                    Id = i.ToString(),
                    Nombre = nombre,
                    Apellido = DataGenerator.GenerateRandomApellido(),
                    TipoDocumento = DataGenerator.GenerateRandomTipoDocumento(),
                    NumeroDocumento = DataGenerator.GenerateRandomNumeroDocumento(),
                    Email = DataGenerator.GenerateRandomEmail(nombre),
                    Telefono = DataGenerator.GenerateRandomPhone(),
                    PasswordHash = DataGenerator.GenerateRandomPassword(),
                    Direccion = DataGenerator.GenerateRandomAddress(),
                    FechaRegistro = DateTime.UtcNow.AddDays(-1),
                    Estado = "Activo",
                    Preferencia = DataGenerator.GenerateRandomPreferences()
                });
            }
        }
        public List<string> GetRolesUsuario(Usuario usuario)
        {
            return _userManager.GetRolesAsync(usuario).Result.ToList();
        }

        public void AddUsuario(Usuario usuario, string roleName)
        {
            usuarios.Add(usuario);
        }

        public void DeleteUsuario(string id)
        {
            var usuario = usuarios.FirstOrDefault(c => c.Id == id);
            if(usuario != null){
                usuarios.Remove(usuario);
            }
        }

        public Usuario? GetUsuarioById(string id)
        {
            var usuario = usuarios.FirstOrDefault(c => c.Id == id);
            return usuario;
        }
        public Usuario? GetUsuarioByEmail(string email)
        {
            var usuario = usuarios.FirstOrDefault(c => c.Email == email);
            return usuario;
        }

        public List<Usuario> GetUsuarios()
        {
            return usuarios;
        }

        public void UpdateUsuario(Usuario usuario)
        {
            var indice = usuarios.FindIndex(c => c.Id.Equals(usuario.Id));
            if(indice > -1)
            {
                usuarios[indice] = usuario;
            }

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