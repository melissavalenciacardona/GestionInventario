namespace LabSoft.DTOs
{
    public class ProductoRequestDTO
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string? FechaExpiracion { get; set; }
        public string ProveedorId { get; set; }
    }
}