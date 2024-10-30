
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
            throw new NotImplementedException();
        }

        public Preferencia? GetPreferenciaById(string id)
        {
            throw new NotImplementedException();
        }
    }
}