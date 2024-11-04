
namespace LabSoft.Data.Repositorio
{
    public class PreferenciaRepository : IPreferenciaRepository
    {
        private readonly MyDbContext _context;

        public PreferenciaRepository(MyDbContext context){
            _context = context;
        }

        public void AddPreferencia(Preferencia preferencia)
        {
            preferencia.Id = Guid.NewGuid().ToString();
            var result = _context.Preferencia.Add(preferencia);
            _context.SaveChanges();
        }

        public List<Preferencia> GetPreferencia()
        {
            var preferencias = _context.Preferencia.ToList();
            return preferencias;
        }

        public Preferencia? GetPreferenciaById(string id)
        {
            var result = _context.Preferencia
            .FirstOrDefault(preferenciaId => preferenciaId.Id.Equals(id));
            return result;
        }
    }
}