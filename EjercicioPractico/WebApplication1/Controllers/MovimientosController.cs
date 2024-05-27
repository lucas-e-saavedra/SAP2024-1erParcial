using BusinessLayer;
using DomainModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovimientoController : ControllerBase
    {
        private readonly ILogger<MovimientoController> _logger;

        public MovimientoController(ILogger<MovimientoController> logger)
        {
            _logger = logger;
            
        }

        [HttpGet(Name = "GetMovimientos")]
        public IEnumerable<Movimiento> Get()
        {
            return GestorMovimientos.Instance.GetMovimientos();
        }

        /*[HttpGet("{idTienda}", Name = "GetUnaTienda")]
        public Tienda Get(int idTienda)
        {
            return GestorMovimie.Instance.GetUnaTienda(idTienda);
        }*/

        [HttpPost(Name = "AddMovimientoADeposito")]
        public bool Send([FromQuery]int IdOrigen, [FromQuery] int IdDepositoDestino, [FromQuery] int IdTiendaDestino, StockItem[] detalle)
        {
            Deposito origen = GestorEstablecimientos.Instance.GetUnDeposito(IdOrigen);
            Establecimiento destino = null;
            if (IdDepositoDestino > 0 && IdTiendaDestino == 0) { 
                destino = GestorEstablecimientos.Instance.GetUnDeposito(IdDepositoDestino);
            } else if (IdDepositoDestino == 0 && IdTiendaDestino > 0) {
                destino = GestorEstablecimientos.Instance.GetUnaTienda(IdTiendaDestino);
            } else { 
                return false;
            }
            
            DateTime fecha = DateTime.Now;
            Usuario unUsuario = new Usuario() { 
                Nombre = "Lucas"
            };

            Movimiento unMovimiento = new Movimiento() { 
                Origen = origen,
                Destino = destino,
                Fecha = fecha,
                Detalle = detalle.ToList(),
                Responsable = unUsuario
            };

            return GestorMovimientos.Instance.AddMovimiento(unMovimiento);
        }

    }
}
