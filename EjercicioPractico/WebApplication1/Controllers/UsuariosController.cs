using BusinessLayer;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seguridad;
using System.Globalization;
using System.Net.Http;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly ILogger<UsuariosController> _logger;

        public UsuariosController(ILogger<UsuariosController> logger)
        {
            _logger = logger;
            
        }
        
        [HttpGet("login",Name = "IniciarSesion")]
        public Usuario Get([FromQuery] string user, [FromQuery] string password)
        {
            return GestorSeguridad.Instance.ValidarUsuario(user, password);
        }
    }

    public class Credenciales {
        public string email { get; set; }
        public string password { get; set; }
    }
}
