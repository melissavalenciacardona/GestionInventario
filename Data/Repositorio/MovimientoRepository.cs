
using Microsoft.EntityFrameworkCore;

namespace LabSoft.Data.Repositorio
{
    public class MovimientoRepository : IMovimientoRepository
    {
        private readonly MyDbContext _context;

        public MovimientoRepository(MyDbContext context){
            _context = context;
        }

        public void AddMovimiento(Movimiento movimiento)
        {
            movimiento.Id = Guid.NewGuid().ToString();
            var result = _context.Movimiento.Add(movimiento);
            _context.SaveChanges();
        }

        public List<Movimiento> GetMovimiento()
        {
            var movimientos = _context.Movimiento
            .Include(producto => producto.Producto)
            .ThenInclude(proveedor => proveedor.Proveedor)
            .ThenInclude(direccion => direccion.Direccion)
            .ToList();
            return movimientos;
        }

        public List<Movimiento>? GetMovimientoById(string ProductoId)
        {
            var result = _context.Movimiento
            .Include(producto => producto.Producto)
            .ThenInclude(proveedor => proveedor.Proveedor)
            .ThenInclude(direccion => direccion.Direccion)
            .Where(movimiento => movimiento.ProductoId == ProductoId)
            .ToList();
            return result;
        }
    }
}