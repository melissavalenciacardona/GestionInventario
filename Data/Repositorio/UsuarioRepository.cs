
namespace LabSoft.Data.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private static readonly List<Usuario> usuarios = new List<Usuario>();

        static UsuarioRepository()
        {
            for (int i = 0; i < 5; i++)
            {
                var nombre = DataGenerator.GenerateRandomName();
                usuarios.Add(new Usuario
                {
                    Id = i.ToString(),
                    Nombre = nombre,
                    Apellido = DataGenerator.GenerateRandomLastName(),
                    TipoDocumento = DataGenerator.GenerateRandomDNIType(),
                    NumeroDocumento = DataGenerator.GenerateRandomDNI(),
                    Email = DataGenerator.GenerateRandomEmail(nombre),
                    Telefono = DataGenerator.GenerateRandomPhone(),
                    Direccion = DataGenerator.GenerateRandomAddress(),
                    FechaRegistro = DateTime.UtcNow.AddDays(-1),
                    Estado = "Activo",
                    Preferencia = DataGenerator.GenerateRandomPreferences(),
                    Password = DataGenerator.GenerateRandomPassword()
                });
            }
        }

        public void AddUsuario(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public void DeleteUsuario(string id)
        {
            var usuario = usuarios.FirstOrDefault(c => c.Id == id);
            if (usuario != null)
            {
                usuarios.Remove(usuario);
            }
        }

        public Usuario? GetUsuarioById(string id)
        {
            var usuario = usuarios.FirstOrDefault(c => c.Id == id);
            return usuario;
        }

        public Usuario? GetUsuarioByEmail(string Email)
        {
            var usuario = usuarios.FirstOrDefault(c => c.Email == Email);
            return usuario;
        }

        public List<Usuario> GetUsuarios()
        {
            return usuarios;
        }

        public void UpdateUsuario(Usuario usuario)
        {
            var indice = usuarios.FindIndex(c => c.Id.Equals(usuario.Id));
            if (indice > -1)
            {
                usuarios[indice] = usuario;
            }

        }

        public void UpdateUsuarioState(string id, string state)
        {
            var usuario = usuarios.FirstOrDefault(c => c.Id == id);
            if (usuario != null && usuario.Estado != state && (state == "Activo" || state == "Inactivo"))
            {
                usuario.Estado = state;
            }
        }
    }
}