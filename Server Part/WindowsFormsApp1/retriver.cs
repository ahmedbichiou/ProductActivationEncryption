using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class retriver
    {
        
        public string macRETRIVER(int numb)
        {
            
            String numbSTR = numb.ToString();
            const string connectionString = @"SERVER = .\SQLEXPRESS ; DATABASE = licenceDB ; Trusted_Connection=True ";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
            SqlCommand command = new SqlCommand($"select mac from ClientData where id='{numbSTR}'");
            command.Connection = conn;
            conn.Open();
            string mac = (string)command.ExecuteScalar();
                return mac;
            }
            
            
            
            
            
        }
    }
}
