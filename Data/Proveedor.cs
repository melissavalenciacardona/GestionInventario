namespace LabSoft.Data
{
    public class Proveedor
    {
        public string Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string DireccionId { get; set; }
        public Direccion Direccion { get; set; }
    }
}
