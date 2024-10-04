using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insertion_test
{
    class retriever
    {
        public Boolean stateRETRIVER(string mac)
        {



            connection a = new connection();
            string connection = a.getConn();
            string connectionString = connection;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand($"select state from ClientData where mac='{mac}'");
            command.Connection = conn;
            conn.Open();
            if (command.ExecuteScalar() == null)
            {
                return false;
            }
            else
            {
                Boolean state = (Boolean)command.ExecuteScalar();
                conn.Close();
                return state;
            }
        }
        
    }
}
