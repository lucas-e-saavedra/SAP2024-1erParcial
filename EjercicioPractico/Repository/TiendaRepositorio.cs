using DomainModel;

namespace Repository
{
    public class TiendaRepositorio : IRepositorioGenerico<Tienda>
    {
        private IList<Tienda> _listaDeTiendas;
        private ProductoRepositorio productoRepositorio;
        public TiendaRepositorio() { 
            _listaDeTiendas = new List<Tienda>();
            productoRepositorio = new ProductoRepositorio();

            Direccion direccionTienda1 = new Direccion() { 
                Calle = "Parana",
                Numero = 6796,
                Localidad = "Villa Adelina (Vte Lopez)",
                CodigoPostal = "B1607",
                Provincia = "Buenos Aires"
            };
            IEnumerable<Producto> productos = productoRepositorio.ObtenerTodos();
            List<StockItem> stockItems = new List<StockItem>();
            foreach (var producto in productos)
            {
                StockItem item = new StockItem() { 
                    producto = producto,
                    cantidad = 10
                };
                stockItems.Add(item);
            }

            Tienda unaTienda = new Tienda() { 
                Id = 1,
                Nombre = "Valusel Villa Adelina",
                Direccion = direccionTienda1,
                Stock = stockItems
            };

            _listaDeTiendas.Add(unaTienda);
        }
        public void AgregarUno(Tienda unObjeto)
        {
            var lastItem = _listaDeTiendas.MaxBy(x => x.Id);
            int maxId = lastItem != null ? lastItem.Id : 0;
            unObjeto.Id = maxId + 1;
            _listaDeTiendas.Add(unObjeto);
        }

        public void BorrarUno(int id)
        {
            Tienda objetoOriginal = _listaDeTiendas.First(x => x.Id == id);
            _listaDeTiendas.Remove(objetoOriginal);
        }

        public void ModificarUno(Tienda unObjeto)
        {
            Tienda objetoOriginal = _listaDeTiendas.First(x => x.Id == unObjeto.Id);
            int index = _listaDeTiendas.IndexOf(objetoOriginal);
            _listaDeTiendas[index] = unObjeto;
        }

        public IEnumerable<Tienda> ObtenerTodos()
        {
            return _listaDeTiendas;
        }

        public Tienda ObtenerUno(int id)
        {
            return _listaDeTiendas.First(t => t.Id == id);
        }
    }
}
