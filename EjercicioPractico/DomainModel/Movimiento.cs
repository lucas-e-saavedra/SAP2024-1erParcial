namespace DomainModel
{
    internal class Movimiento
    {
        public int Id { get; set; }
        public Deposito Origen { get; set; }
        public Establecimiento Destino { get; set; }
        public DateTime Fecha { get; set; }
        public Dictionary<Producto, int> Detalle { get; set; }
        public Usuario Responsable { get; set; }

    }
}
