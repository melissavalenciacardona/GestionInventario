
using LabSoft.Data.Repositorio;

namespace LabSoft.Data.Negocio.Servicios {
    public class ProveedorService : IProveedorService
    {
        private readonly IProveedorRepository _proveedorRepository;

        public ProveedorService(IProveedorRepository proveedorRepository){
            this._proveedorRepository = proveedorRepository;
        }

        public void AddProveedor(Proveedor proveedor)
        {
            _proveedorRepository.AddProveedor(proveedor);
        }

        public void DeleteProveedor(string id)
        {
            _proveedorRepository.DeleteProveedor(id);
        }

        public Proveedor? GetProveedorById(string id)
        {
            return _proveedorRepository.GetProveedorById(id);
        }

        public List<Proveedor> GetProveedores()
        {
            return _proveedorRepository.GetProveedores();
        }

        public void UpdateProveedor(Proveedor proveedor)
        {
            var proveedorUpd = _proveedorRepository.GetProveedorById(proveedor.Id);

            if(proveedorUpd != null){
                proveedorUpd.Nombre = proveedor.Nombre;
                proveedorUpd.Telefono = proveedor.Telefono;

                _proveedorRepository.UpdateProveedor(proveedorUpd);
            }
        }
    }
}