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
    public partial class kayit : Form
    {
        public kayit()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-JLADA8S;Initial Catalog=Kayit;Integrated Security=True;Encrypt=False");
        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty (maskedTextBox1.Text))
            {
                MessageBox.Show("Kullanıcı adı ve şifre alanı boş bırakılamaz");
            }
            else { 
            string doktor = "insert into doktor_kayit(kullanici_adi, sifre, ad, telefon, soyad, bölüm)values(@kullanici_adi, @sifre, @ad, @telefon, @soyad, @bölüm)";
            SqlCommand kayit = new SqlCommand(doktor, baglan);
            kayit.Parameters.AddWithValue("@ad", textBox1.Text);
            kayit.Parameters.AddWithValue("@soyad", textBox2.Text);
            kayit.Parameters.AddWithValue("@kullanici_adi", textBox3.Text);
            kayit.Parameters.AddWithValue("@bölüm", textBox4.Text);
            kayit.Parameters.AddWithValue("@sifre", maskedTextBox1.Text);
            kayit.Parameters.AddWithValue("@telefon", textBox5.Text);
            baglan.Open();
            kayit.ExecuteNonQuery();
            MessageBox.Show("Kaydınız başarılı bir şekilde gerçekleştirilmiştir");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            textBox5.Clear();
            baglan.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show(); 
            this.Close();
        }
    }
}
