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

namespace HastaKayit
{
    public partial class Personel : Form
    {
        public Personel()
        {
            InitializeComponent();
        }

        SqlConnection connect = new SqlConnection(@"Data Source=DESKTOP-JLADA8S;Initial Catalog=Kayit;Integrated Security=True;Encrypt=False");

        private void button1_Click(object sender, EventArgs e)
        {
            ana_ekran frm = new ana_ekran();

            frm.Show();

            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            connect.Open();

            string kayit = "Select * from doktor_kayit Where soyad=@soyad";
            SqlCommand komut = new SqlCommand(kayit, connect); 
            komut.Parameters.AddWithValue("@soyad", textBox1.Text);
            SqlDataAdapter adb = new SqlDataAdapter(komut); 

            DataTable dt = new DataTable();

            adb.Fill(dt);
            dataGridView1.DataSource = dt;

            connect.Close();
        }
        public void kayit()
        {

            connect.Open();
            SqlCommand komut = new SqlCommand("select * from doktor_kayit", connect);
            SqlDataAdapter adp = new SqlDataAdapter(komut);
            DataSet set = new DataSet();
            adp.Fill(set);

           
            dataGridView1.DataSource = set.Tables[0];

            connect.Close();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silmek istediğiniz personeli seçiniz");
                return;
            }

            connect.Open();

            string sil = dataGridView1.SelectedRows[0].Cells["telefon"].Value.ToString();

            string delete = "DELETE FROM doktor_kayit WHERE telefon=@telefon";

            SqlCommand komut = new SqlCommand(delete, connect);
            komut.Parameters.AddWithValue("@telefon", sil);

            int sayi = komut.ExecuteNonQuery();

            connect.Close();



            if (sayi > 0)
            {
                MessageBox.Show("Kayıt Silindi");
                kayit();
            }
            else
            {
                MessageBox.Show("Kayıt silinirken bir hata oluştu");
            }
        }
    }
}
