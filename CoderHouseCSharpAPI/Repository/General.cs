using CoderHouse_CSharp_API.Model;
using System.Data.SqlClient;

namespace CoderHouse_CSharp_API.Repository
{
    public class General
    {
        public static string connectionString()
        {
     
            SqlConnectionStringBuilder connectionbuilder = new SqlConnectionStringBuilder();
            connectionbuilder.DataSource = "AJZET\\SQLEXPRESS";
            connectionbuilder.InitialCatalog = "SistemaGestion";
            connectionbuilder.IntegratedSecurity = true;
            var cs = connectionbuilder.ConnectionString;
            return (cs);

        }
    }
}
