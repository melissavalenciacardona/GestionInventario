
using LabSoft.Data.Repositorio;

namespace LabSoft.Data.Negocio.Servicios {
    public class ProductoService : IProductoService
    {
        private readonly IProductoRepository _productoRepository;

        public ProductoService(IProductoRepository productoRepository){
            this._productoRepository = productoRepository;
        }

        public void AddProducto(Producto producto)
        {
            _productoRepository.AddProducto(producto);
        }

        public void DeleteProducto(string id)
        {
            _productoRepository.DeleteProducto(id);
        }

        public Producto? GetProductoById(string id)
        {
            return _productoRepository.GetProductoById(id);
        }

        public List<Producto> GetProductos()
        {
            return _productoRepository.GetProductos();
        }

        public void UpdateProducto(Producto producto)
        {
            var productoUpd = _productoRepository.GetProductoById(producto.Id);

            if(productoUpd != null){
                productoUpd.Nombre = producto.Nombre;

                _productoRepository.UpdateProducto(productoUpd);
            }
        }
    }
}