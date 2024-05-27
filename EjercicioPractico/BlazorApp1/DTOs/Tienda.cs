namespace BlazorApp1.DTOs
{
    public class Tienda: Establecimiento
    {
        public Direccion? Direccion { get; set; }

        public StockItem[]? Stock { get; set; }
    }
}
