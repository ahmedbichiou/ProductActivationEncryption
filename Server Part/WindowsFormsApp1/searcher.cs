using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class searcher
    {
        public Boolean found(int numb)
        {
            String numbSTR = numb.ToString();
            const string connectionString = @"SERVER = .\SQLEXPRESS ; DATABASE = licenceDB ; Trusted_Connection=True ";
            using (SqlConnection conn = new SqlConnection(connectionString))
            { 
                SqlCommand command = new SqlCommand($"select id from Serial where id='{numbSTR}'");
                command.Connection = conn;
                conn.Open();
                if (command.ExecuteScalar() == null)
                {
                    return false;
                }
                else
                {
                
                    return true;
                }
            }  
        }
    }
}
