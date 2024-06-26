using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace HastaKayit
{
    public partial class ana_ekran : Form
    {
        public ana_ekran()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-JLADA8S;Initial Catalog=Kayit;Integrated Security=True;Encrypt=False");

        private void button1_Click(object sender, EventArgs e)
        {
            Hasta_kayit frm = new Hasta_kayit();

            frm.Show();
            
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Liste frm = new Liste();

            frm.Show();

            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-JLADA8S;Initial Catalog=Kayit;Integrated Security=True;Encrypt=False");
            connect.Open();
            SqlCommand komut = new SqlCommand("select * from hasta_kayit", connect); 
            SqlDataAdapter adp = new SqlDataAdapter(komut); 
            DataSet set = new DataSet();
            adp.Fill(set);

            
            frm.dataGridView1.DataSource = set.Tables[0];

            connect.Close();

            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Personel frm = new Personel();

            frm.Show();

            SqlConnection doktor = new SqlConnection(@"Data Source=DESKTOP-JLADA8S;Initial Catalog=Kayit;Integrated Security=True;Encrypt=False");
            connect.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM doktor_kayit", doktor);
            SqlDataAdapter adc = new SqlDataAdapter(komut);
            DataSet set = new DataSet();
            adc.Fill(set);

            
            frm.dataGridView1.DataSource = set.Tables[0];
            frm.dataGridView1.Columns["kullanici_adi"].Visible = false;
            frm.dataGridView1.Columns["sifre"].Visible = false;
            connect.Close();
            

            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Liste frm = new Liste();

            frm.Show();

            this.Hide();

            SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-JLADA8S;Initial Catalog=Kayit;Integrated Security=True;Encrypt=False");
            connect.Open();
            SqlCommand komut = new SqlCommand("select * from hasta_kayit", connect); 
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataSet set = new DataSet();
            adp.Fill(set);

            
            frm.dataGridView1.DataSource = set.Tables[0];

            connect.Close();


        }

        
            
    }
}
