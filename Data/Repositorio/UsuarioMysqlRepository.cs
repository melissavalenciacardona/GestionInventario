
using Microsoft.EntityFrameworkCore;

namespace LabSoft.Data.Repositorio
{
    public class UsuarioMysqlRepository : IUsuarioRepository
    {
        private readonly MyDbContext _context; //Todos los resposiotrios deben tener un contexto

        public UsuarioMysqlRepository(MyDbContext context) //Inyectando dependencia de la BD
        {
            _context = context;
        }
        public void AddUsuario(Usuario usuario)
        {
            var result = _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }
        public void DeleteUsuario(string id)
        {
            var usuario = _context.Usuario.FirstOrDefault(usuarioId => usuarioId.Id.Equals(id));

            if(usuario != null){
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

        public bool ValidateUsuario(string email, string password)
        {
            var usuario = _context.Usuario.FirstOrDefault(usuarioEmail => usuarioEmail.Email.Equals(email) && usuarioEmail.Password.Equals(password));
            return usuario != null;
        }
    }
}