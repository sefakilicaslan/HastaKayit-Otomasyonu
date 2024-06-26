using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Security.Policy;


namespace HastaKayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-JLADA8S;Initial Catalog=Kayit;Integrated Security=True;Encrypt=False");

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Lütfen kullanıcı adı ve şifre giriniz.");
                return; 
            }

            baglan.Open();
            SqlCommand cmd = new SqlCommand("select * from doktor_kayit where kullanici_adi='" + textBox1.Text + "' and sifre ='"  + textBox2.Text + "'", baglan );
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                ana_ekran frm = new ana_ekran();
                frm.Show();
                textBox1.Clear();
                textBox2.Clear();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanici Adı veya şifresi yanlış girildi");
            }
            baglan.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            kayit kayitForm = new kayit();
            kayitForm.Show();
            this.Hide();

            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
