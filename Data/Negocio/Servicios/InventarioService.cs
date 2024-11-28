
using LabSoft.Data.Repositorio;

namespace LabSoft.Data.Negocio.Servicios
{
    public class InventarioService : IInventarioService
    {
        private readonly IProductoRepository _productoRepository;
        private readonly IMovimientoRepository _movimientoRepository;

        public InventarioService(IProductoRepository productoRepository, IMovimientoRepository movimientoRepository)
        {
            _productoRepository = productoRepository;
            _movimientoRepository = movimientoRepository;
        }

        public Inventario Disminuir(string ProductoId, int cantidad, string motivo)
        {
            var productoActual = _productoRepository.GetProductoById(ProductoId);
            if (productoActual == null)
            {
                throw new Exception("Producto no encontrado");
            }
            var PrimerMovimiento = _movimientoRepository.MovimientoIngreso(ProductoId);
            var movimiento = new Movimiento
            {
                Id = Guid.NewGuid().ToString(),
                ProductoId = productoActual.Id,
                Motivo = motivo,
                Precio = PrimerMovimiento.Precio + 100, // Se aumenta el precio en 100 para ganancia
                Total = (PrimerMovimiento.Precio + 100) * cantidad,
                Cantidad = -cantidad,
                Fecha = DateTime.Now,
                Tipo = "Salida"
            };
            _movimientoRepository.AddMovimiento(movimiento);

            return new Inventario
            {
                Nombre = productoActual.Nombre,
                Categoria = productoActual.Categoria,
                Cantidad = movimiento.Cantidad,
                Precio = movimiento.Precio
            };

        }
        public Inventario Adicionar(string ProductoId, int cantidad, string motivo, decimal precio)
        {
            var productoActual = _productoRepository.GetProductoById(ProductoId);
            if (productoActual == null)
            {
                throw new Exception("Producto no encontrado");
            }


            var movimiento = new Movimiento
            {
                Id = Guid.NewGuid().ToString(),
                ProductoId = productoActual.Id,
                Motivo = motivo,
                Cantidad = cantidad,
                Precio = precio,
                Total = precio * cantidad,
                Fecha = DateTime.Now,
                Tipo = "Entrada"
            };
            _movimientoRepository.AddMovimiento(movimiento);

            return new Inventario
            {
                Nombre = productoActual.Nombre,
                Categoria = productoActual.Categoria,
                Cantidad = movimiento.Cantidad,
                Precio = movimiento.Precio
            };
        }
        public List<Inventario> Buscar(string criterio, string valor)
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
                Cantidad = _movimientoRepository.GetCantidadActual(p.Id),
                Precio = _movimientoRepository.GetPrecioActual(p.Id)
            }).ToList();

            return inventarios;
        }

        public List<Dictionary<string, object>> GetReporte(string criterio, string valor)
        {
            var reporte = new List<Dictionary<string, object>>();
            var productos = _productoRepository.GetProductos();
            if (criterio == "Id")
            {
                productos = productos.Where(p => p.Id.Contains(valor, StringComparison.OrdinalIgnoreCase)).ToList();

            }
            foreach (var producto in productos)
            {
                var inventario = new Dictionary<string, object>
                {
                    { "Producto", producto.Nombre },
                    { "Saldo", _movimientoRepository.GetCantidadActual(producto.Id) },
                    { "CostoPromedio", _movimientoRepository.CostoPromedio(producto.Id) },
                    { "CostoTotal", _movimientoRepository.CostoTotal(producto.Id) }

                };
                reporte.Add(inventario);
            }
            return reporte;
        }

        public List<string> GetAlertas()
        {
            var productos = _productoRepository.GetProductos();
            var alertas = new List<string>();
            foreach (var producto in productos)
            {
                var cantidad = _movimientoRepository.GetCantidadActual(producto.Id);
                if (cantidad < 5)
                {
                    alertas.Add($"Producto {producto.Nombre} con cantidad {cantidad}");
                    
                    var resultado = _movimientoRepository.GetMovimientoById(producto.Id);
                    decimal Precio;
                    if (resultado.Count == 0)
                    {
                        Precio = 0;
                    }
                    else
                    {
                        var ultimoMovimiento = resultado.Where(m => m.Tipo == "Entrada").Last();
                        Precio = ultimoMovimiento.Precio;
                    }
                    var Total = 10 * Precio;
                    var movimiento = new Movimiento
                    {
                        Id = Guid.NewGuid().ToString(),
                        ProductoId = producto.Id,
                        Precio = Precio,
                        Total = Total,
                        Motivo = "Alerta",
                        Cantidad = 10,
                        Fecha = DateTime.Now,
                        Tipo = "Entrada"
                    };
                    _movimientoRepository.AddMovimiento(movimiento);
                }
            }
            return alertas;
        }

    }
}