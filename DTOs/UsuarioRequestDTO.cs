namespace LabSoft.DTOs
{
    public class UsuarioRequestDTO
    {
        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string DireccionId { get; set; }
        public string PreferenciaId { get; set; }
    }
}