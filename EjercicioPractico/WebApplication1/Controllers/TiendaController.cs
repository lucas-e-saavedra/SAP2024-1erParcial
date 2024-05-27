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

        [HttpGet("{idTienda}", Name = "GetUnaTienda")]
        public Tienda Get(int idTienda)
        {
            return GestorEstablecimientos.Instance.GetUnaTienda(idTienda);
        }

        [HttpPost(Name = "AddTienda")]
        public bool Add(Tienda unaTienda)
        {
            return GestorEstablecimientos.Instance.AddTienda(unaTienda);
        }

        [HttpPut(Name = "UpdateTienda")]
        public bool Update(Tienda unaTienda)
        {
            return GestorEstablecimientos.Instance.UpdateEstablecimiento(unaTienda);
        }

        [HttpDelete("{idTienda}", Name = "RemoveTienda")]
        public bool Remove(int idTienda)
        {
            return GestorEstablecimientos.Instance.RemoveTienda(idTienda);
        }
    }
}
