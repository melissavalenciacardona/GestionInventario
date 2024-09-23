namespace LabSoft.Data
{
    public class Cliente
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

        public Direccion Direccion { get; set; }
        public Preferencia Preferencia { get; set; }

        public string Password { get; set; }


    }
}
