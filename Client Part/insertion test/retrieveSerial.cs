using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insertion_test
{
    class retrieveSerial
    {
        public String SerialRETRIVER()
        {
            Form1 f1 = new Form1();
            string Mac = f1.GetMacAddress();
            retrieveID i = new retrieveID();
            string numb = i.IDRETRIEVER(Mac);

            connection a = new connection();
            string connection = a.getConn();
            string connectionString = connection;
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand($"select activationKey from Serial where id='{numb}'");
            command.Connection = conn;
            conn.Open();
           
            
            if (command.ExecuteScalar() == null)
            {
                return "not found";
            }
            else
            {
                string key = (string)command.ExecuteScalar();
                
                conn.Close();
                return key;
               
            }
            
        }
}
}
