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

namespace HastaKayit
{
    public partial class Hasta_kayit : Form
    {
        public Hasta_kayit()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-JLADA8S;Initial Catalog=Kayit;Integrated Security=True;Encrypt=False");

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrEmpty(kimlik_no.Text) || string.IsNullOrEmpty(ad.Text) || string.IsNullOrEmpty(soyad.Text))
            {
                MessageBox.Show("TC Kimlik Numarası, Ad ve Soyad alanı boş geçilemez. Lütfen bu alanları doldurun.");
                return; 
            }

            if (kimlik_no.Text.Length != 11)
            {
                MessageBox.Show("TC Kimlik numarası 11 haneli olmalıdır");
                return;
            }

            string hasta = "insert into hasta_kayit(Adı, Soyadı, Kimlik_no, Hastalık, Kan_grubu, Doğum_tarihi, Bölüm, Cinsiyet)values(@Adı, @Soyadı, @Kimlik_no, @Hastalık, @Kan_grubu, @Doğum_tarihi, @Bölüm, @Cinsiyet)";
            SqlCommand giris = new SqlCommand(hasta, connect);
            giris.Parameters.AddWithValue("@Adı", ad.Text);
            giris.Parameters.AddWithValue("@Soyadı", soyad.Text);
            giris.Parameters.AddWithValue("@Kimlik_no", kimlik_no.Text);
            giris.Parameters.AddWithValue("@Hastalık", hastalik.Text);
            giris.Parameters.AddWithValue("@Kan_grubu", kan_grubu.Text);
            giris.Parameters.AddWithValue("@Cinsiyet", cinsiyet.Text);
            giris.Parameters.AddWithValue("@Bölüm", bölüm.Text);
            giris.Parameters.AddWithValue("@Doğum_tarihi", dateTimePicker1.Value);
            connect.Open();
            giris.ExecuteNonQuery();
            MessageBox.Show("Hasta kayıdı başarılı bir şekilde gerçekleştirilmiştir");
            ad.Clear();
            soyad.Clear();
            kimlik_no.Clear();
            hastalik.Clear();
            kan_grubu.SelectedIndex = -1;
            cinsiyet.SelectedIndex = -1;
            bölüm.Clear();
            dateTimePicker1.Value = DateTime.Now;
            connect.Close();
            
        }

        private void Hasta_kayit_Load(object sender, EventArgs e)
        {
            string[] kanGruplari = { "A Rh+", "A Rh-", "B Rh+", "B Rh-", "AB Rh+", "AB Rh-", "0 Rh+", "0 Rh-" };
            kan_grubu.Items.AddRange(kanGruplari);

            string[] cinsiyet = { "Erkek", "Kadın" };
            this.cinsiyet.Items.AddRange(cinsiyet);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ana_ekran frm = new ana_ekran();

            frm.Show();

            this.Hide();
        }

    }
}
