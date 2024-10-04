using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insertion_test
{
    class deletehardwareEntry
    {
        public void deleteEntry(string id)
        {
            connection a = new connection();
            string connection = a.getConn();
            string connectionString = connection;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand($"delete from ClientData where id='{id}'");
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();



        }
    }
}
