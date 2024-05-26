using BusinessLayer;
using DomainModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TiendaController : ControllerBase
    {
        private readonly ILogger<TiendaController> _logger;

        public TiendaController(ILogger<TiendaController> logger)
        {
            _logger = logger;
            
        }

        [HttpGet(Name = "GetTiendas")]
        public IEnumerable<Tienda> Get()
        {
            return GestorEstablecimientos.Instance.GetTiendas();
        }


        [HttpPost(Name = "AddTienda")]
        public bool Add(Tienda unaTienda)
        {
            return GestorEstablecimientos.Instance.AddTienda(unaTienda);
        }
    }
}
