namespace LabSoft.Data
{
    public class Producto
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string? FechaExpiracion { get; set; } // Make FechaExpiracion optional
        public string ProveedorId { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
