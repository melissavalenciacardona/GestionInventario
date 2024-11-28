namespace LabSoft.Data.Repositorio
{
    public interface IMovimientoRepository
    {
        List<Movimiento> GetMovimiento();
        List<Movimiento>? GetMovimientoById(string ProductoId);
        void AddMovimiento(Movimiento movimiento);
        int GetCantidadActual(string ProductoId);
        decimal GetPrecioActual(string ProductoId);
        Movimiento MovimientoIngreso (string ProductoId);
        decimal CostoPromedio(string ProductoId);
        decimal CostoTotal(string ProductoId);
    }
}