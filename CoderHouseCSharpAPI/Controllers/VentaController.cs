using CoderHouse_CSharp_API.Model;
using CoderHouse_CSharp_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoderHouse_CSharp_API.Controllers
{
    [Route("api/Venta")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpGet]
        public List<Venta> Get()
        {
            return ADO_Venta.DevolverVentas();
        }
        [HttpDelete]
        public void Eliminar([FromBody] int id)
        {
            ADO_Venta.EliminarVentas(id);
        }
        [HttpPut]
        public void Modificar([FromBody] Venta venta)
        {
            ADO_Venta.ModificarVentas(venta);
        }
        [HttpPost]
        public void Agregar([FromBody] Venta venta)
        {
            ADO_Venta.AgregarVentas(venta);
        }
    }
}
