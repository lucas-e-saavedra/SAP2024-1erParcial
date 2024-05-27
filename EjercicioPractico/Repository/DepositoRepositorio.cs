using DomainModel;

namespace Repository
{
    public class DepositoRepositorio : IRepositorioGenerico<Deposito>
    {
        private IList<Deposito> _listaDeDepositos;
        private ProductoRepositorio productoRepositorio;
        public DepositoRepositorio()
        {
            _listaDeDepositos= new List<Deposito>();
            productoRepositorio = new ProductoRepositorio();
            
            _listaDeDepositos.Add(CrearDepositoA());
            _listaDeDepositos.Add(CrearDepositoB());
        }

        public void AgregarUno(Deposito unObjeto)
        {
            var lastItem = _listaDeDepositos.MaxBy(x => x.Id);
            int maxId = lastItem != null ? lastItem.Id : 0;
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

        #region DATOS PARA PRUEBAS
        private Deposito CrearDepositoA() {
            Direccion direccionDepositoA = new Direccion()
            {
                Calle = "Thames",
                Numero = 2618,
                Localidad = "Boulogne",
                CodigoPostal = "B1609",
                Provincia = "Buenos Aires"
            };

            IEnumerable<Producto> productos = productoRepositorio.ObtenerTodos();
            List<StockItem> stockItemsA = new List<StockItem>();
            foreach (var producto in productos)
            {
                StockItem item = new StockItem()
                {
                    producto = producto,
                    cantidad = 100
                };
                stockItemsA.Add(item);
            }

            Deposito depositoA = new Deposito()
            {
                Id = 1,
                Nombre = "Deposito A",
                Direccion = direccionDepositoA,
                Stock = stockItemsA
            };
            return depositoA;
        }

        private Deposito CrearDepositoB() {
            Direccion direccionDepositoB = new Direccion()
            {
                Calle = "Bernardo de Irigoyen",
                Numero = 696,
                Localidad = "Boulogne",
                CodigoPostal = "B1609",
                Provincia = "Buenos Aires"
            };

            IEnumerable<Producto> productos = productoRepositorio.ObtenerTodos();
            List<StockItem> stockItemsB = new List<StockItem>();
            foreach (var producto in productos)
            {
                StockItem item = new StockItem()
                {
                    producto = producto,
                    cantidad = 100
                };
                stockItemsB.Add(item);
            }

            Deposito depositoB = new Deposito()
            {
                Id = 2,
                Nombre = "Deposito B",
                Direccion = direccionDepositoB,
                Stock = stockItemsB
            };
            return depositoB;
        }
        #endregion
    }
}
