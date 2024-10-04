using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insertion_test
{
    class retrieveID
    {
        public string IDRETRIEVER(string mac)
        {



            connection a = new connection();
            string connection = a.getConn();
            string connectionString = connection;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand($"select id from ClientData where mac='{mac}'");
            command.Connection = conn;
            conn.Open();
            if (command.ExecuteScalar() == null)
            {
                return "not found";
            }
            else
            {
                string id = (string)command.ExecuteScalar();
                conn.Close();
                return id;
            }
        }
    }
}
