using DomainModel;

namespace Repository
{
    public class MovimientoRepositorio : IRepositorioGenerico<Movimiento>
    {
        private List<Movimiento> _listaDeMovimientos;
        private ProductoRepositorio productoRepositorio;
        public MovimientoRepositorio() { 
            _listaDeMovimientos = new List<Movimiento>();
            _listaDeMovimientos.AddRange(datosParaPruebas());
        }
        public void AgregarUno(Movimiento unObjeto)
        {
            var lastItem = _listaDeMovimientos.MaxBy(x => x.Id);
            int maxId = lastItem!=null ?lastItem.Id :0;
            unObjeto.Id = maxId + 1;
            _listaDeMovimientos.Add(unObjeto);
        }

        public void BorrarUno(int id)
        {
            throw new NotImplementedException();
        }

        public void ModificarUno(Movimiento unObjeto)
        {
             throw new NotImplementedException();
        }

        public IEnumerable<Movimiento> ObtenerTodos()
        {
            return _listaDeMovimientos;
        }

        public Movimiento ObtenerUno(int id)
        {
            return _listaDeMovimientos.First(t => t.Id == id);
        }

        #region DATOS PARA SIMULAR PRUEBAS
        private List<Movimiento> datosParaPruebas() {
            List<Deposito> depositos = new DepositoRepositorio().ObtenerTodos().ToList();
            List<Tienda> tiendas = new TiendaRepositorio().ObtenerTodos().ToList();
            List<Producto> productos = new ProductoRepositorio().ObtenerTodos().ToList();
            Usuario unUsuario = new Usuario() { 
                Nombre = "Lucas"
            };

            List<Movimiento> movs = new List<Movimiento>();

            List<StockItem> detalleA = new List<StockItem>();
            detalleA.Add(new StockItem() { 
                producto = productos.First(),
                cantidad = 15
            });
            List<StockItem> detalleB = new List<StockItem>();
            detalleB.Add(new StockItem()
            {
                producto = productos.First(),
                cantidad = 5
            });
            detalleB.Add(new StockItem()
            {
                producto = productos.Last(),
                cantidad = 8
            });

            Movimiento mov1 = new Movimiento() { 
                Id = 1,
                Origen = depositos.First(),
                Destino = tiendas.First(),
                Fecha = DateTime.Now.AddDays(-20),
                Detalle = detalleA,
                Responsable = unUsuario
            };
            movs.Add(mov1);

            Movimiento mov2 = new Movimiento()
            {
                Id = 2,
                Origen = depositos.First(),
                Destino = tiendas.First(),
                Fecha = DateTime.Now.AddDays(-19),
                Detalle = detalleB,
                Responsable = unUsuario
            };
            movs.Add(mov2);

            Movimiento mov3 = new Movimiento()
            {
                Id = 3,
                Origen = depositos.First(),
                Destino = depositos.Last(),
                Fecha = DateTime.Now.AddDays(-17),
                Detalle = detalleA,
                Responsable = unUsuario
            };
            movs.Add(mov3);

            Movimiento mov4 = new Movimiento()
            {
                Id = 4,
                Origen = depositos.First(),
                Destino = tiendas.First(),
                Fecha = DateTime.Now.AddDays(-16),
                Detalle = detalleA,
                Responsable = unUsuario
            };
            movs.Add(mov4);

            Movimiento mov5 = new Movimiento()
            {
                Id = 5,
                Origen = depositos.First(),
                Destino = depositos.Last(),
                Fecha = DateTime.Now.AddDays(-15),
                Detalle = detalleB,
                Responsable = unUsuario
            };
            movs.Add(mov5);
            return movs;
        }
        #endregion
    }
}
