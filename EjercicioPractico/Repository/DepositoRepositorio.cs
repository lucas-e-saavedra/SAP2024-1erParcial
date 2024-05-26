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
            int maxId = _listaDeDepositos.MaxBy(x => x.Id).Id;
            unObjeto.Id = maxId + 1;
            _listaDeDepositos.Add(unObjeto);
        }

        public void BorrarUno(int id)
        {
            Deposito objetoOriginal = _listaDeDepositos.First(x => x.Id == id);
            _listaDeDepositos.Remove(objetoOriginal);
        }

        public void ModificarUno(Deposito unObjeto)
        {
            Deposito objetoOriginal = _listaDeDepositos.First(x => x.Id == unObjeto.Id);
            int index = _listaDeDepositos.IndexOf(objetoOriginal);
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
