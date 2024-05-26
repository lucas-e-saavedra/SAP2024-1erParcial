using BusinessLayer;
using DomainModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepositoController : ControllerBase
    {
        private readonly ILogger<DepositoController> _logger;

        public DepositoController(ILogger<DepositoController> logger)
        {
            _logger = logger;
            
        }

        [HttpGet(Name = "GetDepositos")]
        public IEnumerable<Deposito> Get()
        {
            return GestorEstablecimientos.Instance.GetDepositos();
        }

        [HttpGet("{idDeposito}", Name = "GetUnDeposito")]
        public Deposito Get(int idDeposito)
        {
            return GestorEstablecimientos.Instance.GetUnDeposito(idDeposito);
        }

        [HttpPost(Name = "AddDeposito")]
        public bool Add(Deposito unDeposito) { 
            return GestorEstablecimientos.Instance.AddDeposito(unDeposito);
        }

        [HttpPut(Name = "UpdateDeposito")]
        public bool Update(Deposito unDeposito)
        {
            return GestorEstablecimientos.Instance.UpdateDeposito(unDeposito);
        }

        [HttpDelete("{idDeposito}", Name = "RemoveDeposito")]
        public bool Remove(int idDeposito)
        {
            return GestorEstablecimientos.Instance.RemoveDeposito(idDeposito);
        }
    }
}
