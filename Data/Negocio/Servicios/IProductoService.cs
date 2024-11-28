namespace LabSoft.Data.Negocio.Servicios
{
    public interface IProductoService{
        List<Producto> GetProductos();
        Producto? GetProductoById(string id);
        void AddProducto(ProductoTemporal producto);
        void UpdateProducto(Producto producto);
        void DeleteProducto(string id);
    }
}