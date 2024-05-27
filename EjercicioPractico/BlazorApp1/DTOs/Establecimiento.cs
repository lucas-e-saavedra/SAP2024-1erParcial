namespace BlazorApp1.DTOs
{
    public class Establecimiento
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public Direccion? Direccion { get; set; }

        public List<StockItem>? Stock { get; set; }
    }
}
