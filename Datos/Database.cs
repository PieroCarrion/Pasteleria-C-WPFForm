using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace Datos
{
    public class Database
    {
        private SqlConnection conn;
        public SqlConnection ConectarDB()
        {
            try
            {
                string cadenaconexion = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=pastelDB;Integrated Security=true";
                conn = new SqlConnection(cadenaconexion);
                conn.Open();
                return conn;
            }
            catch(SqlException s)
            {
                return null;
            }
        }
        public void DesconectarDB()
        {
            conn.Close();
        }
    }
}
