using CoderHouse_CSharp_API.Model;
using CoderHouse_CSharp_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoderHouse_CSharp_API.Controllers
{
    [Route("api/ProductoVendido")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet]
        public List<ProductoVendido> Get()
        {
            return ADO_ProductoVendido.DevolverProductosVendidos();
        }
        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
            ADO_ProductoVendido.EliminarProductosVendidos(id);
        }
        [HttpPut]
        public void Modificar([FromBody] ProductoVendido productovendido)
        {
            ADO_ProductoVendido.ModificarProductosVendidos(productovendido);
        }
        [HttpPost]
        public void Agregar([FromBody]ProductoVendido productovendido)
        {
            ADO_ProductoVendido.AgregarProductosVendidos(productovendido);
        }
    }
}
