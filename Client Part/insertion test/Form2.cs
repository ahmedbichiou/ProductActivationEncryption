using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace insertion_test
{
    public partial class Form2 : Form
    {
        public static class Globals
        {
            public static String KeySTR = "0";
           
        }
        public Form2()
        {
            InitializeComponent();
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
            field1.Text = numb;
            if (command.ExecuteScalar() == null)
            {
                
            }
            else
            {
                string key = (string)command.ExecuteScalar();
                Globals.KeySTR = key.ToString();
                conn.Close();
                field1.Text = Globals.KeySTR;
            }

        }

        private void Activate_Click(object sender, EventArgs e)
        {

            retrieveSerial rt =  new retrieveSerial();
            string  serial = rt.SerialRETRIVER();
            String key = field1.Text;
            if(serial == key)
            {
                
              
                textBox1.Text = "produit activé";
                updateActivation ua = new updateActivation();
                ua.updater(true);
                System.Threading.Thread.Sleep(2000);
                Form3 f3 = new Form3();
                this.Hide();
                f3.Show();
            }
            else
            {
                textBox3.Text = "Licnece incorrect";
            }
           



        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            string Mac = f1.GetMacAddress();
            retrieveID i = new retrieveID();
            string numb = i.IDRETRIEVER(Mac);
            deletehardwareEntry d = new deletehardwareEntry();
            d.deleteEntry(numb);
            this.Hide();
            f1.Show();
        }
    }
}
