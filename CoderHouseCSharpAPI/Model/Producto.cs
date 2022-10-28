using System.Data.SqlTypes;

namespace CoderHouse_CSharp_API.Model
{
    public class Producto
    {
        public int Id { get; set; }
        public string Descripciones { get; set; }

        public SqlMoney Costo { get; set; }
        public SqlMoney PrecioVenta    { get; set; }    
        public int Stock { get; set; }
        public int IdUsuario { get; set; }
    }
}
