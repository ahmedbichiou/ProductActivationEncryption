using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            


            
            while (true)

            {
                System.Threading.Thread.Sleep(1000);

                  counter ct = new counter();
                    int numb = ct.counting() - 1;
                    String numbSTR = numb.ToString();

                
                searcher s = new searcher();
                Boolean fnd = s.found(numb);
               
                if (fnd == false)
                {
                   

                    retriver rt = new retriver();
                    string macSTR = rt.macRETRIVER(numb);

                   
                    if (numbSTR == "-1")
                    {
                        Console.WriteLine(" ");
                    }
                    else {
                        var key = "b14ca5898a4e4133bbce2ea2315a1916";
                        var encryptedString = AesOperation.EncryptString(key, macSTR);

                        const string connectionString = @"SERVER = .\SQLEXPRESS ; DATABASE = licenceDB ; Trusted_Connection=True ";

                        System.Data.SqlClient.SqlConnection sqlConnection1 = new System.Data.SqlClient.SqlConnection(connectionString);

                        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                        cmd.CommandType = System.Data.CommandType.Text;

                        var activationDay = DateTime.Now;
                        var expirationDay = DateTime.Now.AddMonths(3);

                        String dateBegin = activationDay.ToString();
                        String dateexp = expirationDay.ToString();
                        
                        cmd.CommandText = $"INSERT INTO Serial VALUES ('{numbSTR}','{encryptedString}','0','{dateBegin}','{dateexp}')";
                        cmd.Connection = sqlConnection1;

                        sqlConnection1.Open();
                        cmd.ExecuteNonQuery();
                        sqlConnection1.Close();
                    }
                }
                
                else
                {
                    
                    Console.WriteLine(" ");
                }
            }
                

            }
        

        private void Form1_Load(object sender, EventArgs e)
        {

        }



    }
        
        
      

        
    
}
