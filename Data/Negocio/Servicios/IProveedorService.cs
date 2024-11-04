namespace LabSoft.Data.Negocio.Servicios
{
    public interface IProveedorService {
        List<Proveedor> GetProveedores();
        Proveedor? GetProveedorById(string id);
        void AddProveedor(Proveedor proveedor);
        void UpdateProveedor(Proveedor proveedor);
        void DeleteProveedor(string id);
    }
}