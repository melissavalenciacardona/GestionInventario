using Microsoft.AspNetCore.Identity;

namespace LabSoft.Data
{
    public class Usuario : IdentityUser
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; }
        public string PasswordHash { get; set; }
        public string DireccionId { get; set; }
        public string PreferenciaId { get; set; }


        public Direccion Direccion { get; set; }
        public Preferencia Preferencia { get; set; }


    }
}
