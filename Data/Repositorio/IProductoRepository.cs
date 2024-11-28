namespace LabSoft.Data.Repositorio
{
    public interface IProductoRepository {
        List<Producto> GetProductos();
        Producto? GetProductoById(string id);
        void AddProducto(ProductoTemporal producto);
        void UpdateProducto(Producto producto);
        void DeleteProducto(string id);
    }
}