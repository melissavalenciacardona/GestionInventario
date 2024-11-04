namespace LabSoft.DTOs
{
    public class ProductoResponseDTO
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string? FechaExpiracion { get; set; }
        public ProveedorResponseDTO Proveedor { get; set; }
    }
}