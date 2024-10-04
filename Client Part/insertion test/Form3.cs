using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace insertion_test
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

            Form1 f1 = new Form1();
            string mac = f1.GetMacAddress();

            connection con = new connection();
            string connectionstring = con.getConn();
           

               retrieveDate rd = new retrieveDate();
            string date = rd.dateRET(connectionstring,mac);
               DateTime dateT = Convert.ToDateTime(date);
           
                DateTime toDay = DateTime.Now;
                int datecomp = DateTime.Compare(toDay, dateT);
                if (datecomp >0)
                { 
                Boolean state= false;
               updateActivation ua = new updateActivation();
                ua.updater(state);
               Application.Run(new Form1());
             
                }
            else
            {
            activation b = new activation();
            Boolean act = b.activationRETRIVER();
            if(act == false)
            {
                
           Application.Run(new Form1());
            }
            }
           





          
            
            
            retrieveModulesStates rms = new retrieveModulesStates();
            Boolean Achatstate = rms.Achatstate(connectionstring, mac);
            Boolean Ventestate = rms.Ventestate(connectionstring, mac);
            Boolean Stockstate = rms.Stockstate(connectionstring, mac);
            Boolean PointVentestate = rms.PointVentestate(connectionstring, mac);
            if(Achatstate == false)
            {
                label5.ForeColor = Color.Black;
                label5.Text = "Module Achat   " +
                    "(Indisponible)";
                pictureBox8.Hide();
            }
            if (Ventestate == false)
            {
                label6.ForeColor = Color.Black;
                label6.Text = "Module Vente   " +
                    "(Indisponible)";
                pictureBox9.Hide();
            }

            if (Stockstate == false)
            {
                label2.ForeColor = Color.Black;
                label2.Text = "Module Stock   " +
                    "(Indisponible)";
                pictureBox10.Hide();
            }

            if (PointVentestate == false)
            {
                label1.ForeColor = Color.Black;
                label1.Text = "Module Point de Vente (Indisponible)";
                pictureBox11.Hide();
            }



        }

        private void Form3_Load(object sender, EventArgs e)
        {
           


        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void Activate_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
