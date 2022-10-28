using CoderHouse_CSharp_API.Model;
using System.Data;
using System.Data.SqlClient;

namespace CoderHouse_CSharp_API.Repository
{
    public class ADO_Venta
    {
        public static List<Venta> DevolverVentas()
        {
            var listaVentas = new List<Venta>();
           

            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM venta";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var venta = new Venta();
                    venta.Id = Convert.ToInt32(reader.GetValue(0));
                    venta.Comentarios = reader.GetValue(1).ToString();
                    venta.IdUsuario = Convert.ToInt32(reader.GetValue(2));
                    listaVentas.Add(venta);

                }
                reader.Close();
                connection.Close();
            }
            return listaVentas;



        }
        public static void EliminarVentas(int id)
        {
            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "DELETE FROM venta WHERE id = @idVenta";
                var parametro = new SqlParameter();
                parametro.ParameterName = "idVenta";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = id;

                cmd2.Parameters.Add(parametro);
                cmd2.ExecuteNonQuery();
                connection.Close();

            }
        }
        public static void ModificarVentas(Venta venta)
        {
            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd3 = connection.CreateCommand();
                cmd3.CommandText = "UPDATE venta SET Id=@id, Comentarios=@comentarios,IdUsuario=@idusuario";
                var parmID = new SqlParameter();
                parmID.ParameterName = "id";
                parmID.SqlDbType = SqlDbType.BigInt;
                parmID.Value = venta.Id;

                var parmComentarios = new SqlParameter();
                parmComentarios.ParameterName = "comentarios";
                parmComentarios.SqlDbType = SqlDbType.VarChar;
                parmComentarios.Value = venta.Comentarios;

                var parmIdUsuario = new SqlParameter();
                parmIdUsuario.ParameterName = "idusuario";
                parmIdUsuario.SqlDbType = SqlDbType.BigInt;
                parmIdUsuario.Value = venta.IdUsuario;

                cmd3.Parameters.Add(parmID);
                cmd3.Parameters.Add(parmComentarios);
                cmd3.Parameters.Add(parmIdUsuario);
                cmd3.ExecuteNonQuery();
                connection.Close();

            }
        }
        public static void AgregarVentas(Venta venta)
        {

            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd4 = connection.CreateCommand();
                cmd4.CommandText = "INSERT INTO producto (Id,Comentarios,IdUsuario)" + "values(@id,@comentarios,@idusuario)";
                var parmID = new SqlParameter();
                parmID.ParameterName = "id";
                parmID.SqlDbType = SqlDbType.BigInt;
                parmID.Value = venta.Id;

                var parmComentarios = new SqlParameter();
                parmComentarios.ParameterName = "comentarios";
                parmComentarios.SqlDbType = SqlDbType.VarChar;
                parmComentarios.Value = venta.Comentarios;

                var parmIdUsuario = new SqlParameter();
                parmIdUsuario.ParameterName = "idusuario";
                parmIdUsuario.SqlDbType = SqlDbType.BigInt;
                parmIdUsuario.Value = venta.IdUsuario;

                cmd4.Parameters.Add(parmID);
                cmd4.Parameters.Add(parmComentarios);
                cmd4.Parameters.Add(parmIdUsuario);
                cmd4.ExecuteNonQuery();
                connection.Close();

            }
        }
    }
}
