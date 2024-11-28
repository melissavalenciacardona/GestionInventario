namespace LabSoft.DTOs
{
    public class CreacionProductoRequestDTO
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public string? FechaExpiracion { get; set; }
        public string ProveedorId { get; set; }
    }
}