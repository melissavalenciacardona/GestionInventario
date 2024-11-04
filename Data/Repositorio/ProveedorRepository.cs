
using Microsoft.EntityFrameworkCore;

namespace LabSoft.Data.Repositorio
{
    public class ProveedorRepository : IProveedorRepository
    {
        private readonly MyDbContext _context;

        public ProveedorRepository(MyDbContext context){
            _context = context;
        }

        public void AddProveedor(Proveedor proveedor)
        {
            proveedor.Id = Guid.NewGuid().ToString();
            
            var result = _context.Proveedor.Add(proveedor);
            _context.SaveChanges();
        }

        public void DeleteProveedor(string id)
        {
            var proveedor = _context.Proveedor.FirstOrDefault(proveedorId => proveedorId.Id.Equals(id));

            if(proveedor != null){
                _context.Proveedor.Remove(proveedor);
                _context.SaveChanges();
            }
        }

        public List<Proveedor> GetProveedores()
        {
            var proveedors = _context.Proveedor
            .Include(direccion => direccion.Direccion)
            .ToList();
            return proveedors;
        }

        public Proveedor? GetProveedorById(string id)
        {
            var result = _context.Proveedor
            .Include(direccion => direccion.Direccion)
            .FirstOrDefault(proveedorId => proveedorId.Id.Equals(id));
            return result;
        }
        public void UpdateProveedor(Proveedor proveedor)
        {
            var result = _context.Proveedor.Update(proveedor);
            _context.SaveChanges();
        }
    }
}