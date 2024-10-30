namespace LabSoft.Data.Negocio.Servicios
{
    public interface IDireccionService {
        List<Direccion> GetDireccion();
        Direccion? GetDireccionById(string id);
        void AddDireccion(Direccion direccion);
    }
}