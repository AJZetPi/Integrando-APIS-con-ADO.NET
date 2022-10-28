using CoderHouse_CSharp_API.Model;
using CoderHouse_CSharp_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoderHouse_CSharp_API.Controllers
{
    [Route("api/Producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet]
        public List<Producto> Get()
        {
            return ADO_Producto.DevolverProductos();
        }
        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
            ADO_Producto.EliminarProductos(id);
        }
        [HttpPut]
        public void Modificar([FromBody] Producto producto)
        {
            ADO_Producto.ModificarProductos(producto);
        }
        [HttpPost]
        public void Agregar([FromBody] Producto producto)
        {
            ADO_Producto.AgregarProductos(producto);
        }
    }
}
