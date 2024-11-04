
namespace LabSoft.Data.Repositorio
{

    public class UserRepository : IUserRepository //Si esta sale en rojo, le das click y genera la interfaz
    {
        private readonly MyDbContext _context; //Todos los resposiotrios deben tener un contexto
        public UserRepository(MyDbContext context) //Inyectando dependencia de la BD
        {
            _context = context;
        }
        public void AddUsuario(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
        public ApplicationUser? GetUsuarioById(string id)
        {
            throw new NotImplementedException();
        }
        public List<ApplicationUser> GetUsuarios()
        {
            throw new NotImplementedException();
        }
    }
}