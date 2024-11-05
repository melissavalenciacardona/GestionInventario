namespace LabSoft.Data.Negocio.Servicios
{
    public interface IMovimientoService {
        List<Movimiento> GetMovimiento();
        List<Movimiento>? GetMovimientoById(string ProductoId);
        void AddMovimiento(Movimiento movimiento);
    }
}