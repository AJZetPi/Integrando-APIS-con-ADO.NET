using CoderHouse_CSharp_API.Model;
using System.Data;
using System.Data.SqlClient;

namespace CoderHouse_CSharp_API.Repository
{
    public class ADO_Producto
    {
        public static List<Producto> DevolverProductos()
        {
            var listaProductos = new List<Producto>();
      

            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM producto";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var producto = new Producto();
                    producto.Id = Convert.ToInt32(reader.GetValue(0));
                    producto.Descripciones = reader.GetValue(1).ToString();
                    producto.Costo = Convert.ToInt32(reader.GetValue(2));
                    producto.PrecioVenta = Convert.ToInt32(reader.GetValue(3));
                    producto.Stock = Convert.ToInt32(reader.GetValue(4));
                    producto.IdUsuario = Convert.ToInt32(reader.GetValue(5));
                    listaProductos.Add(producto);
                }
                reader.Close();
                connection.Close();
            }
            return listaProductos;



        }
        public static void EliminarProductos(int id)
        {
            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "DELETE FROM producto WHERE id = @idProducto";
                var parametro = new SqlParameter();
                parametro.ParameterName = "idProducto";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = id;

                cmd2.Parameters.Add(parametro);
                cmd2.ExecuteNonQuery();
                connection.Close();

            }
        }
        public static void ModificarProductos(Producto producto)
        {
            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd3 = connection.CreateCommand();
                cmd3.CommandText = "UPDATE producto SET Id=@id, Descripciones=@descripciones, Costo=@costo,PrecioVenta=@precioventa,Stock=@stock,IdUsuario=@idusuario";
                var parmID = new SqlParameter();
                parmID.ParameterName = "id";
                parmID.SqlDbType = SqlDbType.BigInt;
                parmID.Value = producto.Id;

                var parmDescripciones = new SqlParameter();
                parmDescripciones.ParameterName = "descripciones";
                parmDescripciones.SqlDbType = SqlDbType.VarChar;
                parmDescripciones.Value = producto.Descripciones;

                var parmCosto = new SqlParameter();
                parmCosto.ParameterName = "costo";
                parmCosto.SqlDbType = SqlDbType.Money;
                parmCosto.Value = producto.Costo;

                var parmPrecioVenta = new SqlParameter();
                parmPrecioVenta.ParameterName = "precioventa";
                parmPrecioVenta.SqlDbType = SqlDbType.Money;
                parmPrecioVenta.Value = producto.PrecioVenta;

                var parmStock = new SqlParameter();
                parmStock.ParameterName = "stock";
                parmStock.SqlDbType = SqlDbType.Int;
                parmStock.Value = producto.Stock;

                var parmIdUsuario = new SqlParameter();
                parmIdUsuario.ParameterName = "idusuario";
                parmIdUsuario.SqlDbType = SqlDbType.BigInt;
                parmIdUsuario.Value = producto.IdUsuario;

                cmd3.Parameters.Add(parmID);
                cmd3.Parameters.Add(parmDescripciones);
                cmd3.Parameters.Add(parmCosto);
                cmd3.Parameters.Add(parmPrecioVenta);
                cmd3.Parameters.Add(parmStock);
                cmd3.Parameters.Add(parmIdUsuario);
                cmd3.ExecuteNonQuery();
                connection.Close();

            }
        }
        public static void AgregarProductos(Producto producto)
        {

            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd4 = connection.CreateCommand();
                cmd4.CommandText = "INSERT INTO producto (Id, Descripciones, Costo,PrecioVenta,Stock,IdUsuario)" + "values(@id,@descripciones,@costo,@precioventa,@stock,@idusuario)";
                var parmID = new SqlParameter();
                parmID.ParameterName = "id";
                parmID.SqlDbType = SqlDbType.BigInt;
                parmID.Value = producto.Id;

                var parmDescripciones = new SqlParameter();
                parmDescripciones.ParameterName = "descripciones";
                parmDescripciones.SqlDbType = SqlDbType.VarChar;
                parmDescripciones.Value = producto.Descripciones;

                var parmCosto = new SqlParameter();
                parmCosto.ParameterName = "costo";
                parmCosto.SqlDbType = SqlDbType.Money;
                parmCosto.Value = producto.Costo;

                var parmPrecioVenta = new SqlParameter();
                parmPrecioVenta.ParameterName = "precioventa";
                parmPrecioVenta.SqlDbType = SqlDbType.Money;
                parmPrecioVenta.Value = producto.PrecioVenta;

                var parmStock = new SqlParameter();
                parmStock.ParameterName = "stock";
                parmStock.SqlDbType = SqlDbType.Int;
                parmStock.Value = producto.Stock;

                var parmIdUsuario = new SqlParameter();
                parmIdUsuario.ParameterName = "idusuario";
                parmIdUsuario.SqlDbType = SqlDbType.BigInt;
                parmIdUsuario.Value = producto.IdUsuario;

                cmd4.Parameters.Add(parmID);
                cmd4.Parameters.Add(parmDescripciones);
                cmd4.Parameters.Add(parmCosto);
                cmd4.Parameters.Add(parmPrecioVenta);
                cmd4.Parameters.Add(parmStock);
                cmd4.Parameters.Add(parmIdUsuario);
                cmd4.ExecuteNonQuery();
                connection.Close();

            }
        }
    }
}

