
using LabSoft.Data.Repositorio;

namespace LabSoft.Data.Negocio.Servicios {
    public class InventarioService : IInventarioService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMovimientoRepository _movimientoRepository;

        public InventarioService(IProductoRepository productoRepository, IMovimientoRepository movimientoRepository)
        {
            _productoRepository = productoRepository;
            _movimientoRepository = movimientoRepository;
        }

        public Inventario Disminuir( string ProductoId, int cantidad, string motivo )
        {
            var productoActual = _productoRepository.GetProductoById(ProductoId);
            if (productoActual == null)
            {
                throw new Exception("Producto no encontrado");
            }
            if (productoActual.Cantidad < cantidad)
            {
                throw new Exception("No hay suficiente cantidad de producto");
            }
            productoActual.Cantidad -= cantidad;

            _productoRepository.UpdateProducto(productoActual);
            
            var movimiento = new Movimiento
            {
                Id = Guid.NewGuid().ToString(),
                ProductoId = productoActual.Id,
                Motivo = motivo,
                Cantidad = cantidad,
                Fecha = DateTime.Now,
                Tipo = "Salida"
            };
            _movimientoRepository.AddMovimiento(movimiento);

            return new Inventario
            {
                Nombre = productoActual.Nombre,
                Categoria = productoActual.Categoria,
                Cantidad = productoActual.Cantidad,
                Precio = productoActual.Precio
            };

        }
        public Inventario Adicionar( string ProductoId, int cantidad, string motivo )
        {
            var productoActual = _productoRepository.GetProductoById(ProductoId);
            if (productoActual == null)
            {
                throw new Exception("Producto no encontrado");
            }
            productoActual.Cantidad += cantidad;

            _productoRepository.UpdateProducto(productoActual);
            
            var movimiento = new Movimiento
            {
                Id = Guid.NewGuid().ToString(),
                ProductoId = productoActual.Id,
                Motivo = motivo,
                Cantidad = cantidad,
                Fecha = DateTime.Now,
                Tipo = "Entrada"
            };
            _movimientoRepository.AddMovimiento(movimiento);

            return new Inventario
            {
                Nombre = productoActual.Nombre,
                Categoria = productoActual.Categoria,
                Cantidad = productoActual.Cantidad,
                Precio = productoActual.Precio
            };
        }
        public List<Inventario> Buscar( string criterio, string valor )
        {
            var productos = _productoRepository.GetProductos();
            switch (criterio.ToLower())
            {
                case "nombre":
                    productos = productos.Where(p => p.Nombre.Contains(valor, StringComparison.OrdinalIgnoreCase)).ToList();
                    break;
                case "categoria":
                    productos = productos.Where(p => p.Categoria.Contains(valor, StringComparison.OrdinalIgnoreCase)).ToList();
                    break;
                default:
                    break;
            }
            var inventarios = productos.Select(p => new Inventario
            {
                Nombre = p.Nombre,
                Categoria = p.Categoria,
                Cantidad = p.Cantidad,
                Precio = p.Precio
            }).ToList();
            
            return inventarios;
        }

    }
}