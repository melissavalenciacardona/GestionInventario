
using LabSoft.Data.Repositorio;

namespace LabSoft.Data.Negocio.Servicios {
    public class PreferenciaService : IPreferenciaService
    {
        private readonly IPreferenciaRepository _preferenciaRepository;

        public PreferenciaService(IPreferenciaRepository preferenciaRepository){
            this._preferenciaRepository = preferenciaRepository;
        }

        public void AddPreferencia(Preferencia preferencia)
        {
            _preferenciaRepository.AddPreferencia(preferencia);
        }

        public List<Preferencia> GetPreferencia()
        {
            return _preferenciaRepository.GetPreferencia();
        }

        public Preferencia? GetPreferenciaById(string id)
        {
            return _preferenciaRepository.GetPreferenciaById(id);
        }
    }
}