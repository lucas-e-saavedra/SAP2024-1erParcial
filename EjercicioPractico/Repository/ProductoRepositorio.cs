using DomainModel;

namespace Repository
{
    public class ProductoRepositorio : IRepositorioGenerico<Producto>
    {
        private IList<Producto> _listaDeProductos;
        public ProductoRepositorio()
        {
            _listaDeProductos = new List<Producto>();

            Producto productoA = new Producto() { 
                Id = 1,
                Nombre = "Tazón",
                Descripcion = "Tazón gigante especial para el cafe con leche",
                Precio = 1500
            };
            _listaDeProductos.Add(productoA);

            Producto productoB = new Producto()
            {
                Id = 2,
                Nombre = "Bowl",
                Descripcion = "Bowl para usar en ensaladas",
                Precio = 2500
            };
            _listaDeProductos.Add(productoB);

            Producto productoC = new Producto()
            {
                Id = 3,
                Nombre = "Florero",
                Descripcion = "Florero con forma de sifon",
                Precio = 2000
            };
            _listaDeProductos.Add(productoC);
        }

        public void AgregarUno(Producto unObjeto)
        {
            var lastItem = _listaDeProductos.MaxBy(x => x.Id);
            int maxId = lastItem != null ? lastItem.Id : 0;
            unObjeto.Id = maxId + 1;
            _listaDeProductos.Add(unObjeto);
        }

        public void BorrarUno(int id)
        {
            Producto objetoOriginal = _listaDeProductos.First(x => x.Id == id);
            _listaDeProductos.Remove(objetoOriginal);
        }

        public void ModificarUno(Producto unObjeto)
        {
            Producto objetoOriginal = _listaDeProductos.First(x => x.Id == unObjeto.Id);
            int index = _listaDeProductos.IndexOf(objetoOriginal);
            _listaDeProductos[index] = unObjeto;
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            return _listaDeProductos;
        }

        public Producto ObtenerUno(int id)
        {
            return _listaDeProductos.First(t => t.Id == id);
        }

    }
}
