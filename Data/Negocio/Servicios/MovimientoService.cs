
using LabSoft.Data.Repositorio;


namespace LabSoft.Data.Negocio.Servicios {
    public class MovimientoService : IMovimientoService
    {
        private readonly IMovimientoRepository _movimientoRepository;

        public MovimientoService(IMovimientoRepository movimientoRepository){
            this._movimientoRepository = movimientoRepository;
        }

        public void AddMovimiento(Movimiento movimiento)
        {
            _movimientoRepository.AddMovimiento(movimiento);
        }

        public List<Movimiento> GetMovimiento()
        {
            return _movimientoRepository.GetMovimiento();
        }

        public List<Movimiento>? GetMovimientoById(string ProductoId)
        {
            return _movimientoRepository.GetMovimientoById(ProductoId);
        }
    }
}