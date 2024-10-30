
using LabSoft.Data.Repositorio;

namespace LabSoft.Data.Negocio.Servicios {
    public class DireccionService : IDireccionService
    {
        private readonly IDireccionRepository _direccionRepository;

        public DireccionService(IDireccionRepository direccionRepository){
            this._direccionRepository = direccionRepository;
        }

        public void AddDireccion(Direccion direccion)
        {
            _direccionRepository.AddDireccion(direccion);
        }

        public List<Direccion> GetDireccion()
        {
            return _direccionRepository.GetDireccion();
        }

        public Direccion? GetDireccionById(string id)
        {
            return _direccionRepository.GetDireccionById(id);
        }
    }
}