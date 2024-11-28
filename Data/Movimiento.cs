namespace LabSoft.Data
{
    public class Movimiento {
        public string Id { get; set; }
        public string Tipo { get; set; }
        public string Motivo { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }
        public string ProductoId { get; set; }

        public Producto Producto { get; set; }
    }
}