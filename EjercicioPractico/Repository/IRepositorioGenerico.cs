using System;
using System.Collections.Generic;
using System.Linq;
namespace Repository
{
    public interface IRepositorioGenerico<T>
    {
        public IEnumerable<T> ObtenerTodos();
        public T ObtenerUno(int id);
        public void AgregarUno(T unObjeto);
        public void BorrarUno(T unObjeto); 
        public void ModificarUno(T unObjeto);
    }
}
