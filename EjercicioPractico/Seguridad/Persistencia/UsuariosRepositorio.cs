using DomainModel;
using Seguridad.Entidades;

namespace Seguridad.Persistencia
{
    public class UsuariosRepositorio
    {
        private List<UsuarioYCredenciales> _listaDeUsuarios;

        public UsuariosRepositorio()
        {
            _listaDeUsuarios = new List<UsuarioYCredenciales>();
            _listaDeUsuarios.AddRange(datosParaPruebas());
        }
        public void AgregarUno(UsuarioYCredenciales unObjeto)
        {
            unObjeto.UserGuid = Guid.NewGuid();
            _listaDeUsuarios.Add(unObjeto);
        }

        public void BorrarUno(Guid id)
        {
            throw new NotImplementedException();
        }

        public void ModificarUno(UsuarioYCredenciales unObjeto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ObtenerTodos()
        {
            return _listaDeUsuarios;
        }

        public UsuarioYCredenciales ObtenerUno(Guid guid)
        {
            return _listaDeUsuarios.First(t => t.UserGuid == guid);
        }

        #region DATOS PARA SIMULAR PRUEBAS
        private List<UsuarioYCredenciales> datosParaPruebas()
        {
            List<UsuarioYCredenciales> usuarios = new List<UsuarioYCredenciales>();
            UsuarioYCredenciales user1 = new UsuarioYCredenciales()
            {
                UserGuid = Guid.Parse("435b4e44-9ed9-44ec-9cef-b82300a15341"),
                Apellido = "Saavedra",
                Nombre = "Lucas",
                Email = "lucas@saavedra.com",
                Password = "qwer"
            };
            usuarios.Add(user1);

            UsuarioYCredenciales user2 = new UsuarioYCredenciales()
            {
                UserGuid = Guid.Parse("21f697c5-e714-4fe4-b444-0da36628a5c2"),
                Apellido = "Pig",
                Nombre = "Pepa",
                Email = "pepa@pig.com",
                Password = "pepa"
            };
            usuarios.Add(user2);

            UsuarioYCredenciales user3 = new UsuarioYCredenciales()
            {
                UserGuid = Guid.Parse("f9d577e6-2ac8-4ed8-a920-71412f8a98bc"),
                Apellido = "Del 8",
                Nombre = "Chavo",
                Email = "chavo@del8.com",
                Password = "chavo"
            };
            usuarios.Add(user3);
            return usuarios;
        }
        #endregion
    }
}















