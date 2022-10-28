using CoderHouse_CSharp_API.Model;
using CoderHouse_CSharp_API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace CoderHouse_CSharp_API.Controllers
{
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        [HttpGet]
        public List<Usuario> Get()
        {
            return ADO_Usuario.DevolverUsuarios();
        }

        [HttpDelete]
        public void Eliminar([FromBody] int id) 
        {
            ADO_Usuario.EliminarUsuarios(id);
        }
        [HttpPut]
        public void Modificar([FromBody] Usuario usuario)
        {
            ADO_Usuario.ModificarUsuarios(usuario);
        }
        [HttpPost]
        public void Agregar([FromBody] Usuario usuario)
        {
            ADO_Usuario.AgregarUsuarios(usuario);
        }
    }
}
