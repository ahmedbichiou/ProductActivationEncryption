using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace insertion_test
{
    class retrieveModulesStates
    {
        public Boolean Ventestate(string connectionString, string Mac)
        {


            retrieveID i = new retrieveID();
            string numb = i.IDRETRIEVER(Mac);


            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand($"select Vente from ClientData where id='{numb}'");
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
        public Boolean Achatstate(string connectionString, string Mac)
        {


            retrieveID i = new retrieveID();
            string numb = i.IDRETRIEVER(Mac);


            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand($"select Achat from ClientData where id='{numb}'");
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
        public Boolean Stockstate(string connectionString, string Mac)
        {


            retrieveID i = new retrieveID();
            string numb = i.IDRETRIEVER(Mac);


            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand($"select Stock from ClientData where id='{numb}'");
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
        public Boolean PointVentestate(string connectionString, string Mac)
        {


            retrieveID i = new retrieveID();
            string numb = i.IDRETRIEVER(Mac);


            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand($"select PointVente from ClientData where id='{numb}'");
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
