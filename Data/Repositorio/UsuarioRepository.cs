
namespace LabSoft.Data.Repositorio
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private static readonly List<Usuario> usuarios = new List<Usuario>();

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
                    Password = DataGenerator.GenerateRandomPassword(),
                    Direccion = DataGenerator.GenerateRandomAddress(),
                    FechaRegistro = DateTime.UtcNow.AddDays(-1),
                    Estado = "Activo",
                    Preferencia = DataGenerator.GenerateRandomPreferences()
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
        public bool ValidateUsuario(string email, string password)
        {
            var usuario = usuarios.FirstOrDefault(c => c.Email == email && c.Password == password);
            return usuario != null;
        }
    }
}