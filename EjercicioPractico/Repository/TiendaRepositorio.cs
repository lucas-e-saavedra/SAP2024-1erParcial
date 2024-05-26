using DomainModel;

namespace Repository
{
    public class TiendaRepositorio : IRepositorioGenerico<Tienda>
    {
        private IList<Tienda> _listaDeTiendas;
        public TiendaRepositorio() { 
            _listaDeTiendas = new List<Tienda>();

            Direccion direccionTienda1 = new Direccion() { 
                Calle = "Parana",
                Numero = 6796,
                Localidad = "Villa Adelina (Vte Lopez)",
                CodigoPostal = "B1607",
                Provincia = "Buenos Aires"
            };
            Producto unProducto = new Producto();
            Tienda unaTienda = new Tienda() { 
                Id = 1,
                Nombre = "Valusel Villa Adelina",
                Direccion = direccionTienda1
            };

            _listaDeTiendas.Add(unaTienda);
        }
        public void AgregarUno(Tienda unObjeto)
        {
            _listaDeTiendas.Add(unObjeto);
        }

        public void BorrarUno(Tienda unObjeto)
        {
            _listaDeTiendas.Remove(unObjeto);
        }

        public void ModificarUno(Tienda unObjeto)
        {
            int index = _listaDeTiendas.IndexOf(unObjeto);
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
