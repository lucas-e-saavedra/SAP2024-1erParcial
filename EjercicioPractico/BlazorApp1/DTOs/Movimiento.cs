namespace BlazorApp1.DTOs
{
    public class Movimiento
    {
        public int Id { get; set; }
        public Deposito Origen { get; set; }
        public Establecimiento Destino { get; set; }
        public DateTime Fecha { get; set; }
        public List<StockItem> Detalle { get; set; }
        public Usuario Responsable { get; set; }

        public string Resumen() {
            return String.Join(", ", Detalle);
        }
    }
}
