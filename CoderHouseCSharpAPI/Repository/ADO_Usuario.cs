using CoderHouse_CSharp_API.Model;
using Microsoft.AspNetCore.Connections;
using System.Data;
using System.Data.SqlClient;
namespace CoderHouse_CSharp_API.Repository
{
    public class ADO_Usuario
    {
        public static List<Usuario> DevolverUsuarios()
        {
            var listaUsuarios = new List<Usuario>();

            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "SELECT * FROM usuario";
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    var usuario = new Usuario();
                    usuario.Id = Convert.ToInt32(reader.GetValue(0));
                    usuario.Nombre = reader.GetValue(1).ToString();
                    usuario.Apellido = reader.GetValue(2).ToString();
                    usuario.NombreUsuario = reader.GetValue(3).ToString();
                    usuario.Contraseña = reader.GetValue(4).ToString();
                    usuario.Mail = reader.GetValue(5).ToString();
                    listaUsuarios.Add(usuario);
                }
                reader.Close();
                connection.Close();
            }
            return listaUsuarios;
            


        }
        public static void EliminarUsuarios(int id)
        {
            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd2 = connection.CreateCommand();
                cmd2.CommandText = "DELETE FROM usuario WHERE id = @idUsuario";
                var parametro = new SqlParameter();
                parametro.ParameterName = "idUsuario";
                parametro.SqlDbType = SqlDbType.BigInt;
                parametro.Value = id;

                cmd2.Parameters.Add(parametro);
                cmd2.ExecuteNonQuery();
                connection.Close();

            }
        }
        public static void ModificarUsuarios(Usuario usuario)
        {
            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd3 = connection.CreateCommand();
                cmd3.CommandText = "UPDATE usuario SET Id=@id, Nombre=@nombre, Apellido=@apellido,NombreUsario=@nombreusuario,Contraseña=@contraseña,Mail=@mail";
                var parmID = new SqlParameter();
                parmID.ParameterName = "id";
                parmID.SqlDbType = SqlDbType.BigInt;
                parmID.Value = usuario.Id;

                var parmNombre = new SqlParameter();
                parmNombre.ParameterName = "nombre";
                parmNombre.SqlDbType = SqlDbType.VarChar;
                parmNombre.Value = usuario.Nombre;

                var parmApellido = new SqlParameter();
                parmApellido.ParameterName = "apellido";
                parmApellido.SqlDbType = SqlDbType.VarChar;
                parmApellido.Value = usuario.Apellido;

                var parmNombreUsuario = new SqlParameter();
                parmNombreUsuario.ParameterName = "nombreusuario";
                parmNombreUsuario.SqlDbType = SqlDbType.VarChar;
                parmNombreUsuario.Value = usuario.NombreUsuario;

                var parmContraseña = new SqlParameter();
                parmContraseña.ParameterName = "contraseña";
                parmContraseña.SqlDbType = SqlDbType.VarChar;
                parmContraseña.Value = usuario.Contraseña;

                var parmMail = new SqlParameter();
                parmMail.ParameterName = "mail";
                parmMail.SqlDbType = SqlDbType.VarChar;
                parmMail.Value = usuario.Mail;

                cmd3.Parameters.Add(parmID);
                cmd3.Parameters.Add(parmNombre);
                cmd3.Parameters.Add(parmApellido);
                cmd3.Parameters.Add(parmNombreUsuario);
                cmd3.Parameters.Add(parmContraseña);
                cmd3.Parameters.Add(parmMail);
                cmd3.ExecuteNonQuery();
                connection.Close();

            }
        }
        public static void AgregarUsuarios(Usuario usuario)
        {

            using (SqlConnection connection = new SqlConnection(General.connectionString()))
            {
                connection.Open();
                SqlCommand cmd4 = connection.CreateCommand();
                cmd4.CommandText = "INSERT INTO usuario (Id, Nombre, Apellido,NombreUsario,Contraseña,Mail)" + "values(@id,@nombre,@apellido,@nombreusuario,@contraseña,@mail)";
                var parmID = new SqlParameter();
                parmID.ParameterName = "id";
                parmID.SqlDbType = SqlDbType.BigInt;
                parmID.Value = usuario.Id;

                var parmNombre = new SqlParameter();
                parmNombre.ParameterName = "nombre";
                parmNombre.SqlDbType = SqlDbType.VarChar;
                parmNombre.Value = usuario.Nombre;

                var parmApellido = new SqlParameter();
                parmApellido.ParameterName = "apellido";
                parmApellido.SqlDbType = SqlDbType.VarChar;
                parmApellido.Value = usuario.Apellido;

                var parmNombreUsuario = new SqlParameter();
                parmNombreUsuario.ParameterName = "nombreusuario";
                parmNombreUsuario.SqlDbType = SqlDbType.VarChar;
                parmNombreUsuario.Value = usuario.NombreUsuario;

                var parmContraseña = new SqlParameter();
                parmContraseña.ParameterName = "contraseña";
                parmContraseña.SqlDbType = SqlDbType.VarChar;
                parmContraseña.Value = usuario.Contraseña;

                var parmMail = new SqlParameter();
                parmMail.ParameterName = "mail";
                parmMail.SqlDbType = SqlDbType.VarChar;
                parmMail.Value = usuario.Mail;

                cmd4.Parameters.Add(parmID);
                cmd4.Parameters.Add(parmNombre);
                cmd4.Parameters.Add(parmApellido);
                cmd4.Parameters.Add(parmNombreUsuario);
                cmd4.Parameters.Add(parmContraseña);
                cmd4.Parameters.Add(parmMail);
                cmd4.ExecuteNonQuery();
                connection.Close();

            }
        }
    }
}
