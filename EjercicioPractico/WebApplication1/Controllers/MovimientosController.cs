using BusinessLayer;
using DomainModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

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
        public IEnumerable<Movimiento> Get([FromQuery] int idDepositoDestino, [FromQuery] int idTiendaDestino, [FromQuery] bool orderAsc)
        {
            IEnumerable<Movimiento> movimientos = GestorMovimientos.Instance.GetMovimientos();

            if (idDepositoDestino > 0) { 
                movimientos = movimientos.Where(x => x.Destino is Deposito && x.Destino.Id == idDepositoDestino);
            }

            if (idTiendaDestino > 0)
            {
                movimientos = movimientos.Where(x => x.Destino is Tienda && x.Destino.Id == idTiendaDestino);
            }

            if (orderAsc) {
                return movimientos.OrderBy(x => x.Fecha);
            } else {
                return movimientos.OrderByDescending(x => x.Fecha);
            }
        }

        [HttpGet("xDestinoYCantidad/{cantidadRequerida}", Name = "GetMovimientosXDestinoYCantidad")]
        public IEnumerable<Movimiento> Get(int cantidadRequerida, [FromQuery] int idDepositoDestino, [FromQuery] int idTiendaDestino, [FromQuery] bool orderAsc)
        {
            IEnumerable<Movimiento> movimientos = GestorMovimientos.Instance.GetMovimientos();

            if (idDepositoDestino > 0)
            {
                movimientos = movimientos.Where(x => x.Destino is Deposito && x.Destino.Id == idDepositoDestino);
            }

            if (idTiendaDestino > 0)
            {
                movimientos = movimientos.Where(x => x.Destino is Tienda && x.Destino.Id == idTiendaDestino);
            }

            if (cantidadRequerida > 0)
            {
                movimientos = movimientos.GroupBy(m => m.Fecha.Date) // Agrupar por fecha
                        .Where(g => g.Count() > cantidadRequerida)  // Filtrar grupos con más de un movimiento
                        .SelectMany(g => g)         // Aplanar la lista de grupos en una sola lista de movimientos
                        .ToList();

            }

            if (orderAsc)
            {
                return movimientos.OrderBy(x => x.Fecha);
            }
            else
            {
                return movimientos.OrderByDescending(x => x.Fecha);
            }
        }

        [HttpGet("tienda/{idTienda}", Name = "GetMovimientosXTienda")]
        public IEnumerable<Movimiento> Get(int idTienda, [FromQuery] bool orderAsc, [FromQuery] string? dateFrom = null, [FromQuery] string? dateTo = null)
        {
            IEnumerable<Movimiento> movimientos = GestorMovimientos.Instance.GetMovimientos();
            movimientos = movimientos.Where(x => x.Destino is Tienda && x.Destino.Id == idTienda);

            if (!String.IsNullOrWhiteSpace(dateFrom)) {
                DateOnly dateOnlyFrom = DateOnly.ParseExact(dateFrom, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime datetimeFrom = dateOnlyFrom.ToDateTime(TimeOnly.MinValue);
                movimientos = movimientos.Where(x => x.Fecha > datetimeFrom);
            }

            if (!String.IsNullOrWhiteSpace(dateTo))
            {
                DateOnly dateOnlyTo = DateOnly.ParseExact(dateTo, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                DateTime datetimeTo = dateOnlyTo.ToDateTime(TimeOnly.MaxValue);
                movimientos = movimientos.Where(x => x.Fecha < datetimeTo);
            }

            if (orderAsc)
            {
                return movimientos.OrderBy(x => x.Fecha);
            }
            else
            {
                return movimientos.OrderByDescending(x => x.Fecha);
            }
        }

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
