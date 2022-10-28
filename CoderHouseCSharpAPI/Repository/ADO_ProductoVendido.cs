using CoderHouse_CSharp_API.Model;
using System.Data;
using System.Data.SqlClient;

namespace CoderHouse_CSharp_API.Repository
{
    public class ADO_ProductoVendido
    {
        public static List<ProductoVendido> DevolverProductosVendidos()
        {
            var listaProductosVendidos = new List<ProductoVendido>();
           

            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM productovendido";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var productov = new ProductoVendido();
                    productov.Id = Convert.ToInt32(reader.GetValue(0));
                    productov.Stock = Convert.ToInt32(reader.GetValue(1));
                    productov.IdProducto = Convert.ToInt32(reader.GetValue(2));
                    productov.IdVenta = Convert.ToInt32(reader.GetValue(3));

                    listaProductosVendidos.Add(productov);
                }
                reader.Close();
                connection.Close();
            }
            return listaProductosVendidos;



        }
        public static void EliminarProductosVendidos(int id)
        {
            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "DELETE FROM productovendido WHERE id = @idProductoVendido";
                var parametro = new SqlParameter();
                parametro.ParameterName = "idProductoVendido";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = id;

                cmd2.Parameters.Add(parametro);
                cmd2.ExecuteNonQuery();
                connection.Close();

            }
        }
        public static void ModificarProductosVendidos(ProductoVendido productovendido)
        {
            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd3 = connection.CreateCommand();
                cmd3.CommandText = "UPDATE venta SET Id=@id, Stock=@stock,IdProducto=@idproducto,IdVenta=@idventa";
                var parmID = new SqlParameter();
                parmID.ParameterName = "id";
                parmID.SqlDbType = SqlDbType.BigInt;
                parmID.Value = productovendido.Id;

                var parmStock = new SqlParameter();
                parmStock.ParameterName = "stock";
                parmStock.SqlDbType = SqlDbType.Int;
                parmStock.Value = productovendido.Stock;

                var parmIdProducto = new SqlParameter();
                parmIdProducto.ParameterName = "idproducto";
                parmIdProducto.SqlDbType = SqlDbType.BigInt;
                parmIdProducto.Value = productovendido.IdProducto;

                var parmIdVenta = new SqlParameter();
                parmIdVenta.ParameterName = "idusuario";
                parmIdVenta.SqlDbType = SqlDbType.BigInt;
                parmIdVenta.Value = productovendido.IdVenta;

                cmd3.Parameters.Add(parmID);
                cmd3.Parameters.Add(parmStock);
                cmd3.Parameters.Add(parmIdProducto);
                cmd3.Parameters.Add(parmIdVenta);
                cmd3.ExecuteNonQuery();
                connection.Close();

            }
        }
        public static void AgregarProductosVendidos(ProductoVendido productovendido)
        {

            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd4 = connection.CreateCommand();
                cmd4.CommandText = "INSERT INTO producto (Id,Stock,IdProducto,IdVenta)" + "values(@id,@stock,@idproducto,idventa)";
                var parmID = new SqlParameter();
                parmID.ParameterName = "id";
                parmID.SqlDbType = SqlDbType.BigInt;
                parmID.Value = productovendido.Id;

                var parmStock = new SqlParameter();
                parmStock.ParameterName = "stock";
                parmStock.SqlDbType = SqlDbType.Int;
                parmStock.Value = productovendido.Stock;

                var parmIdProducto = new SqlParameter();
                parmIdProducto.ParameterName = "idproducto";
                parmIdProducto.SqlDbType = SqlDbType.BigInt;
                parmIdProducto.Value = productovendido.IdProducto;

                var parmIdVenta = new SqlParameter();
                parmIdVenta.ParameterName = "idventa";
                parmIdVenta.SqlDbType = SqlDbType.BigInt;
                parmIdVenta.Value = productovendido.IdVenta;

                cmd4.Parameters.Add(parmID);
                cmd4.Parameters.Add(parmStock);
                cmd4.Parameters.Add(parmIdProducto);
                cmd4.Parameters.Add(parmIdVenta);
                cmd4.ExecuteNonQuery();
                connection.Close();

            }
        }
    }
}
