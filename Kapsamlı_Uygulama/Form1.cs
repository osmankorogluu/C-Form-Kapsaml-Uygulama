using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kapsamlı_Uygulama
{
    public partial class FrmGiriş : Form
    {
        public FrmGiriş()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=Buyuk_Proje;Integrated Security=True");


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmAnasayfa frm = new FrmAnasayfa();
            frm.Show();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmKayıtOl frm = new FrmKayıtOl();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Kulanici1 Where KulaniciAd=@p1 and KulaniciSifre=@p2", baglanti);
            komut.Parameters.AddWithValue("@p1", textKulaniciAdı.Text);
            komut.Parameters.AddWithValue("@p2", textSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                FrmAnasayfa frm = new FrmAnasayfa();
                frm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Kulanıcı Adınız Veya Şifreniz Yanlış Lütfen Tekrar Deneyiniz.");
            }
            baglanti.Close();
        }
    }
}
