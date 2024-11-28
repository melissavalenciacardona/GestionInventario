namespace LabSoft.DTOs
{
    public class ProductoResponseDTO
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string? FechaExpiracion { get; set; }
        public ProveedorResponseDTO Proveedor { get; set; }
    }
}