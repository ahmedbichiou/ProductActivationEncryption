using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class counter
    {
        public int counting()
        {
         const string connectionString = @"SERVER = .\SQLEXPRESS ; DATABASE = licenceDB ; Trusted_Connection=True ";
        using (SqlConnection conn = new SqlConnection(connectionString))
            { 
            SqlCommand command = new SqlCommand("select count(*) from ClientData");
            command.Connection = conn;
            conn.Open();
            int count = (int)command.ExecuteScalar();
            conn.Close();
            return count;
            }   
        }
    }
}
