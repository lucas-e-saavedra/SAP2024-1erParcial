namespace DomainModel
{
    public abstract class Establecimiento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public Direccion Direccion { get; set; }
        public Dictionary<Producto,int> Stock { get; set; }
                
    }
}
