namespace LabSoft.DTOs
{
    public class MovimientooResponseDTO 
    {
        public string Tipo { get; set; }
        public string Motivo { get; set; }
        public int Cantidad { get; set; }
        public ProductoResponseDTO Producto { get; set; }
    }
}