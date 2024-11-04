namespace LabSoft.Data.Repositorio
{
    public interface IProveedorRepository {
        List<Proveedor> GetProveedores();
        Proveedor? GetProveedorById(string id);
        void AddProveedor(Proveedor proveedor);
        void UpdateProveedor(Proveedor proveedor);
        void DeleteProveedor(string id);
    }
}