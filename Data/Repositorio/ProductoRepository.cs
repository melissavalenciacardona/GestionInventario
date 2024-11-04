
using Microsoft.EntityFrameworkCore;

namespace LabSoft.Data.Repositorio
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly MyDbContext _context;

        public ProductoRepository(MyDbContext context){
            _context = context;
        }

        public void AddProducto(Producto producto)
        {
            producto.Id = Guid.NewGuid().ToString();
            
            var result = _context.Producto.Add(producto);
            _context.SaveChanges();
        }

        public void DeleteProducto(string id)
        {
            var producto = _context.Producto.FirstOrDefault(productoId => productoId.Id.Equals(id));

            if(producto != null){
                _context.Producto.Remove(producto);
                _context.SaveChanges();
            }
        }

        public List<Producto> GetProductos()
        {
            var productos = _context.Producto
                        .Include(proveedor => proveedor.Proveedor)
                        .ThenInclude(direccion => direccion.Direccion)
                        .ToList();
            return productos;
        }

        public Producto? GetProductoById(string id)
        {
            var result = _context.Producto
                        .Include(proveedor => proveedor.Proveedor)
                        .ThenInclude(direccion => direccion.Direccion)
                        .FirstOrDefault(productoId => productoId.Id.Equals(id));
            return result;
        }
        public void UpdateProducto(Producto producto)
        {
            var result = _context.Producto.Update(producto);
            _context.SaveChanges();
        }
    }
}