using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insertion_test
{
    class retrieveDate
    {
        public string dateRET(string connectionString,string Mac)
        {

            
            retrieveID i = new retrieveID();
            string numb = i.IDRETRIEVER(Mac);

           

            

            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand($"select expirationDay from Serial where id='{numb}'");
            command.Connection = conn;
            conn.Open();
            if (command.ExecuteScalar() == null)
            {
                return "5/2/2099 6:43:58 PM";
            }
            
            else
            {
                string date = (string)command.ExecuteScalar();
                conn.Close();
                return date;
            }
        }
    }
}
