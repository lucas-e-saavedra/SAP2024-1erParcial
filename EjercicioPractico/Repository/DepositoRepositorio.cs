using DomainModel;

namespace Repository
{
    public class DepositoRepositorio : IRepositorioGenerico<Deposito>
    {
        private IList<Deposito> _listaDeDepositos;
        public DepositoRepositorio()
        {
            _listaDeDepositos= new List<Deposito>();

            Direccion direccionDepositoA = new Direccion()
            {
                Calle = "Thames",
                Numero = 2618,
                Localidad = "Boulogne",
                CodigoPostal = "B1609",
                Provincia = "Buenos Aires"
            };
            Producto unProducto = new Producto();
            Deposito unDeposito = new Deposito()
            {
                Id = 1,
                Nombre = "Deposito A",
                Direccion = direccionDepositoA
            };

            _listaDeDepositos.Add(unDeposito);
        }

        public void AgregarUno(Deposito unObjeto)
        {
            _listaDeDepositos.Add(unObjeto);
        }

        public void BorrarUno(Deposito unObjeto)
        {
            _listaDeDepositos.Remove(unObjeto);
        }

        public void ModificarUno(Deposito unObjeto)
        {
            int index = _listaDeDepositos.IndexOf(unObjeto);
            _listaDeDepositos[index] = unObjeto;
        }

        public IEnumerable<Deposito> ObtenerTodos()
        {
            return _listaDeDepositos;
        }

        public Deposito ObtenerUno(int id)
        {
            return _listaDeDepositos.First(t => t.Id == id);
        }

    }
}
