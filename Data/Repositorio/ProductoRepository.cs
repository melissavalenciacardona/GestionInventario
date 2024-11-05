
using Microsoft.EntityFrameworkCore;


namespace LabSoft.Data.Repositorio
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly MyDbContext _context;
        private readonly IMovimientoRepository _movimientoRepository;
        public ProductoRepository(MyDbContext context, IMovimientoRepository movimientoRepository){
            _context = context;
            _movimientoRepository = movimientoRepository;
        }
        
        public void AddProducto(Producto producto)
        {
            producto.Id = Guid.NewGuid().ToString();
            var result = _context.Producto.Add(producto);
            _context.SaveChanges();
            
            var movimiento = new Movimiento{
                Id = Guid.NewGuid().ToString(),
                ProductoId = producto.Id,
                Motivo = "Creación de producto",
                Cantidad = producto.Cantidad,
                Fecha = DateTime.Now,
                Tipo = "Entrada"
            };
            _movimientoRepository.AddMovimiento(movimiento);
            
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