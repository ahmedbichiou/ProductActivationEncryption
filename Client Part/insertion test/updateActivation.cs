using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insertion_test
{
    class updateActivation
    {
        public void updater(Boolean state)
        {
           
            Form1 f1 = new Form1();
            string Mac = f1.GetMacAddress();
            retrieveID i = new retrieveID();
            string numb = i.IDRETRIEVER(Mac);




if(state == true)
            {
  connection a = new connection();
            string connection = a.getConn();
            string connectionString = connection;
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand($"update Serial set activation='True' where id='{numb}'");
            
       
            
           
            
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
            }
else if(state = false)
            {
  connection a = new connection();
            string connection = a.getConn();
            string connectionString = connection;
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand command = new SqlCommand($"update Serial set activation='false' where id='{numb}'");
            
       
            
           
            
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
            }
          






        }
    }
}
