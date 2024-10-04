using insertion_test.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace insertion_test
{
    public partial class Form1 : Form
    {
        public static class Globals
        {
            public static String CPU = "0";
            public static String GPU = "0";
            public static String MAC = "0";
            public static Boolean licence= true;
            public static String connectionString ="0";
            public static String date="0";
        }
        public Form1()
        {

            InitializeComponent();
         
            connection a = new connection();
            string connection = a.getConn();
            Globals.connectionString = connection;
           
            string connectionString = connection;

            retrieveDate rd = new retrieveDate();
            string date = rd.dateRET(connectionString,GetMacAddress());
               DateTime dateT = Convert.ToDateTime(date);
            Globals.date=date;
                DateTime toDay = DateTime.Now;
                int datecomp = DateTime.Compare(toDay, dateT);
                if (datecomp > 0)
                {
                    textBox1.Text = $"licence a expiré le {dateT}";
                GenerateKey.Text = "reactivé votre license";
                Globals.licence = false;
                
                textBox2.Hide();
                textBox3.Hide();
                textBox4.Hide();
                textBox5.Hide();
                nom.Hide();
                label4.Hide();
                label3.Hide();
                label2.Hide();
                checkBox3.Hide();
                checkBox2.Hide();
                checkBox1.Hide();
                checkBox4.Hide();
                
                pictureBox3.Hide();
                pictureBox4.Hide();
                pictureBox5.Hide();
                pictureBox6.Hide();
                pictureBox7.Hide();
                pictureBox8.Hide();
                pictureBox9.Hide();
                pictureBox10.Hide();
               

            }
          
           

          






        }















        public void Comp(string type)
        {
            ManagementObjectSearcher mos = new ManagementObjectSearcher("SELECT * FROM " + type);
            if (type == "Win32_processor")
            {
                foreach (ManagementObject mj in mos.Get())
                {

                    Globals.CPU = (string)mj["name"];
                }
            }
            if (type == "Win32_VideoController")
            {
                foreach (ManagementObject mj in mos.Get())
                {

                    Globals.GPU = (string)mj["name"];
                }

            }
        }
        public string GetMacAddress()
        {
            string macAddresses = string.Empty;

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }

            return macAddresses;
        }
          private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void GenerateKey_Click(object sender, EventArgs e)
        {
           
            Boolean Achat= false;

            if(checkBox1.Checked)
            {
                Achat= true;
            }
            else
            {
                Achat = false;
            }

             Boolean Vente= false;

            if(checkBox3.Checked)
            {
                Vente= true ;
            }
            else
            {
                Vente = false ;
            }

             Boolean Stock=false;

            if(checkBox2.Checked)
            {
                Stock= true;
            }
            else 
            {
                Stock = false;
            }

            Boolean PointVente = false;

            if (checkBox4.Checked)
            {
                PointVente = true;
            }
            else
            {
                PointVente = false;
            }



            string entreprise = textBox2.Text;
            string formateur = textBox3.Text;
            string employe = textBox4.Text;
            string localisation = textBox5.Text;

             Comp("Win32_processor");
            Comp("Win32_VideoController");
             Globals.MAC = GetMacAddress();

             counter ct = new counter();
            int numb = ct.counting();
            String numbSTR = numb.ToString();

            retriever rt = new retriever();
            Boolean state = rt.stateRETRIVER(Globals.MAC);
             
                 if (state == false)
                 {
                connection a = new connection();
                 string connection = a.getConn();
                 string connectionString = connection;
               

                System.Data.SqlClient.SqlConnection sqlConnection1 =
                   new System.Data.SqlClient.SqlConnection(connectionString);

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;

               cmd.CommandText = $"INSERT INTO ClientData VALUES ('{numbSTR}','{Globals.CPU}','{Globals.GPU}','{Globals.MAC}','1','{entreprise}','{formateur}','{employe}','{localisation}','{Achat}','{Vente}','{Stock}','{PointVente}')";
                cmd.Connection = sqlConnection1;

                sqlConnection1.Open();
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                 }  
                 else
                 {
                    if(Globals.licence == false)
            {
                 retrieveID rID = new retrieveID();
            string numb2 = rID.IDRETRIEVER(Globals.MAC);
            string connectionString = Globals.connectionString;
               
                 var activationDay = DateTime.Now;
                 var expirationDay = DateTime.Now.AddMonths(3);
                   

                       
            String dateexp = expirationDay.ToString();
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand($"update Serial set expirationDay='{dateexp}' where id='{numb2}'");
            command.Connection = conn;
            conn.Open();
            command.ExecuteNonQuery();
            conn.Close();
                
            }
                  }






            activation b = new activation();
            Boolean act = b.activationRETRIVER();
            if (act == false )
            {
                System.Threading.Thread.Sleep(2000);
                this.Hide();
                Form2 f2 = new Form2();
                f2.Show();
               
            }
            else
            {
               textBox1.Text = $"produit activé et expire le {Globals.date}";
                System.Threading.Thread.Sleep(2000);
                Form3 f3 = new Form3();
                f3.Show();
                this.Hide();
            }

           
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            label2.Visible = false;
            label2.Text = "";
            textBox3.Focus();
        }

        private void nom_Click(object sender, EventArgs e)
        {
            nom.Visible = false;
            nom.Text = "";
            textBox2.Focus();
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
             label4.Visible = false;
            label4.Text = "";
            textBox5.Focus();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
            label3.Text = "";
            textBox4.Focus();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
