using BusinessLayer;
using DomainModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly ILogger<ProductoController> _logger;

        public ProductoController(ILogger<ProductoController> logger)
        {
            _logger = logger;
            
        }

        [HttpGet(Name = "GetProductos")]
        public IEnumerable<Producto> Get()
        {
            return GestorProductos.Instance.GetProductos();
        }

        [HttpGet("{idProducto}", Name = "GetUnProducto")]
        public Producto Get(int idProducto)
        {
            return GestorProductos.Instance.GetUnProducto(idProducto);
        }

        [HttpPost(Name = "AddProducto")]
        public bool Add(Producto unProducto) { 
            return GestorProductos.Instance.AddProducto(unProducto);
        }

        [HttpPut(Name = "UpdateProducto")]
        public bool Update(Producto unProducto)
        {
            return GestorProductos.Instance.UpdateProducto(unProducto);
        }

        [HttpDelete("{idProducto}", Name = "RemoveProducto")]
        public bool Remove(int idProducto)
        {
            return GestorProductos.Instance.RemoveProducto(idProducto);
        }
    }
}
