using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insertion_test
{
    class counter
    {
        public int counting()
        {

            connection a = new connection();
            string connection = a.getConn();
            string connectionString = connection;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("select count(*) from ClientData");
            command.Connection = conn;
            conn.Open();
            int count = (int)command.ExecuteScalar();
            conn.Close();
            return count;
        }
    }
}
