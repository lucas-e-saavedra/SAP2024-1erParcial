﻿using DomainModel;
using Seguridad.Entidades;
using Seguridad.Persistencia;

namespace Seguridad
{
    public class GestorSeguridad
    {
        private static GestorSeguridad _instance = null;
        private static readonly object singletonLock = new object();

        private UsuariosRepositorio usuariosRepositorio = null;
        private GestorSeguridad()
        {
            usuariosRepositorio = new UsuariosRepositorio();
        }

        public static GestorSeguridad Instance
        {
            get
            {
                lock (singletonLock)
                {
                    if (_instance == null)
                    {
                        _instance = new GestorSeguridad();
                    }
                    return _instance;
                }
            }
        }

        public Usuario? BuscarUsuario(Guid guid) { 
            return usuariosRepositorio.ObtenerTodos().FirstOrDefault(x => x.UserGuid == guid);
        }
        public Usuario ValidarUsuario(string email, string password)
        {
            Usuario existeUsuario = usuariosRepositorio.ObtenerTodos().FirstOrDefault(x => x.Email == email);
            if (existeUsuario==null)
                return new Usuario();

            UsuarioYCredenciales usuarioCompleto = usuariosRepositorio.ObtenerUno(existeUsuario.UserGuid);
            if (usuarioCompleto==null || usuarioCompleto.Password != password)
                return new Usuario();
            else
                return usuarioCompleto;
        }

        public IEnumerable<Usuario> ObtenerTodos() { 
            return usuariosRepositorio.ObtenerTodos();
        }
    }
}