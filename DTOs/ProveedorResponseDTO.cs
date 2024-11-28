namespace LabSoft.DTOs
{
    public class ProveedorResponseDTO
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public DireccionResponseDTO Direccion { get; set; }
    }
}