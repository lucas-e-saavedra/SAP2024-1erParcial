namespace BlazorApp1.DTOs
{
    public class Deposito: Establecimiento
    {
        public Direccion? Direccion { get; set; }

        public List<StockItem>? Stock { get; set; }

    }
}
