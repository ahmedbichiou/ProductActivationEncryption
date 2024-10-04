using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insertion_test
{
    class activation
    {
        public Boolean activationRETRIVER()
        {

            Form1 f1 = new Form1();
            string Mac = f1.GetMacAddress();
            retrieveID i = new retrieveID();
            string numb = i.IDRETRIEVER(Mac);

            connection a = new connection();
            string connection = a.getConn();
            string connectionString = connection;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand($"select activation from Serial where id='{numb}'");
            command.Connection = conn;
            conn.Open();
            if (command.ExecuteScalar() == null)
            {
                return false;
            }
            else
            {
                Boolean activation = (Boolean)command.ExecuteScalar();
                conn.Close();
                return activation;
            }
           

        }
    }
}
