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

        [HttpPost(Name = "AddDeposito")]
        public bool Add(Deposito unDeposito) { 
            return GestorEstablecimientos.Instance.AddDeposito(unDeposito);
        }
    }
}
