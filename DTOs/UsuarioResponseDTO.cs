namespace LabSoft.DTOs
{
    public class UsuarioResponseDTO
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string PasswordHash { get; set; }

        public DireccionResponseDTO Direccion { get; set; }
        public PreferenciaResponseDTO Preferencia { get; set; }
    }
}