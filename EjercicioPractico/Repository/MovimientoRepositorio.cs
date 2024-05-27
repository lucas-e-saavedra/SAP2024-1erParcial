using DomainModel;

namespace Repository
{
    public class MovimientoRepositorio : IRepositorioGenerico<Movimiento>
    {
        private IList<Movimiento> _listaDeMovimientos;
        private ProductoRepositorio productoRepositorio;
        public MovimientoRepositorio() { 
            _listaDeMovimientos = new List<Movimiento>();
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
    }
}
