using DomainModel;
using Repository;

namespace BusinessLayer
{
    public class GestorMovimientos
    {
        private static GestorMovimientos _instance = null;
        private static readonly object singletonLock = new object();

        private MovimientoRepositorio movimientossRepositorio = null;
        private GestorMovimientos() {
            movimientossRepositorio = new MovimientoRepositorio();
        }

        public static GestorMovimientos Instance {
            get {
                lock (singletonLock) {
                    if (_instance == null) { 
                        _instance = new GestorMovimientos();
                    }
                    return _instance;
                }
            }
        }

        public IEnumerable<Movimiento> GetMovimientos() {
            return movimientossRepositorio.ObtenerTodos();
        }

        public bool AddMovimiento(Movimiento unMovimiento)
        {
            try
            {
                foreach (var itemAEnviar in unMovimiento.Detalle)
                {
                    StockItem itemDisponible = unMovimiento.Origen.Stock.First(x => x.producto.Id == itemAEnviar.producto.Id);
                    if (itemDisponible == null || itemDisponible.cantidad < itemAEnviar.cantidad) {
                        throw new Exception("No se puede enviar esta cantidad xq no hay suficiente");
                    } else { 
                        itemDisponible.cantidad = itemDisponible.cantidad - itemAEnviar.cantidad;
                        if (unMovimiento.Destino.Stock.Any(x => x.producto.Id == itemAEnviar.producto.Id))
                        {
                            StockItem itemRecibido = unMovimiento.Destino.Stock.First(x => x.producto.Id == itemAEnviar.producto.Id);
                            itemRecibido.cantidad = itemRecibido.cantidad + itemAEnviar.cantidad;
                        }
                        else 
                        {
                            unMovimiento.Destino.Stock.Add(itemAEnviar);
                        }
                    }
                }

                GestorEstablecimientos.Instance.UpdateEstablecimiento(unMovimiento.Origen);
                GestorEstablecimientos.Instance.UpdateEstablecimiento(unMovimiento.Destino);
                movimientossRepositorio.AgregarUno(unMovimiento);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
