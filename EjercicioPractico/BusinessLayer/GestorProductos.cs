using DomainModel;
using Repository;

namespace BusinessLayer
{
    public class GestorProductos
    {
        private static GestorProductos _instance = null;
        private static readonly object singletonLock = new object();

        private ProductoRepositorio productossRepositorio = null;
        private GestorProductos() {
            productossRepositorio = new ProductoRepositorio();
        }

        public static GestorProductos Instance {
            get {
                lock (singletonLock) {
                    if (_instance == null) { 
                        _instance = new GestorProductos();
                    }
                    return _instance;
                }
            }
        }

        public IEnumerable<Producto> GetProductos() {
            return productossRepositorio.ObtenerTodos();
        }

        public Producto GetUnProducto(int id)
        {
            return productossRepositorio.ObtenerUno(id);
        }

        public bool AddProducto(Producto unProducto)
        {
            try
            {
                productossRepositorio.AgregarUno(unProducto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateProducto(Producto unProducto)
        {
            try
            {
                productossRepositorio.ModificarUno(unProducto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool RemoveProducto(int idProducto)
        {
            try
            {
                productossRepositorio.BorrarUno(idProducto);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
