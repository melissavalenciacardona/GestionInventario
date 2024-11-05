namespace LabSoft.Data.Repositorio
{
    public interface IMovimientoRepository
    {
        List<Movimiento> GetMovimiento();
        List<Movimiento>? GetMovimientoById(string ProductoId);
        void AddMovimiento(Movimiento movimiento);
    }
}