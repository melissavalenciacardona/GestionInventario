namespace LabSoft.Data.Negocio.Servicios
{
    public interface IInventarioService {
        List<Inventario> Buscar( string criterio, string valor );
        Inventario Disminuir( string ProductoId, int cantidad, string motivo );
        Inventario Adicionar( string ProductoId, int cantidad, string motivo );
    }
}