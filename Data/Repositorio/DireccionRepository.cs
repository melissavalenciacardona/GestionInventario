
namespace LabSoft.Data.Repositorio
{
    public class DireccionRepository : IDireccionRepository
    {
        private readonly MyDbContext _context;

        public DireccionRepository(MyDbContext context){
            _context = context;
        }

        public void AddDireccion(Direccion direccion)
        {
            direccion.Id = Guid.NewGuid().ToString();
            var result = _context.Direccion.Add(direccion);
            _context.SaveChanges();
        }

        public List<Direccion> GetDireccion()
        {
            var direcciones = _context.Direccion.ToList();
            return direcciones;
        }

        public Direccion? GetDireccionById(string id)
        {
            var result = _context.Direccion
            .FirstOrDefault(direccionId => direccionId.Id.Equals(id));
            return result;
        }
    }
}