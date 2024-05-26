using DomainModel;
using Repository;

namespace BusinessLayer
{
    public class GestorEstablecimientos
    {
        private static GestorEstablecimientos _instance = null;
        private static readonly object singletonLock = new object();

        private DepositoRepositorio depositosRepositorio = null;
        private TiendaRepositorio tiendasRepositorio = null;
        private GestorEstablecimientos() {
            depositosRepositorio = new DepositoRepositorio();
            tiendasRepositorio = new TiendaRepositorio();
        }

        public static GestorEstablecimientos Instance {
            get {
                lock (singletonLock) {
                    if (_instance == null) { 
                        _instance = new GestorEstablecimientos();
                    }
                    return _instance;
                }
            }
        }

        public IEnumerable<Deposito> GetDepositos() {
            return depositosRepositorio.ObtenerTodos();
        }

        public bool AddDeposito(Deposito unDeposito)
        {
            try
            {
                depositosRepositorio.AgregarUno(unDeposito);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<Tienda> GetTiendas()
        {
            return tiendasRepositorio.ObtenerTodos();
        }

        public bool AddTienda(Tienda unaTienda)
        {
            try
            {
                tiendasRepositorio.AgregarUno(unaTienda);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
