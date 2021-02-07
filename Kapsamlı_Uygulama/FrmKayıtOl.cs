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
    public partial class FrmKayıtOl : Form
    {
        public FrmKayıtOl()
        {
            InitializeComponent();
        }
        SqlConnection Baglanti = new SqlConnection("Data Source=.;Initial Catalog=Buyuk_Proje;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            FrmGiriş frm = new FrmGiriş();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Kulanici1 (KulaniciTC,KulaniciAd,KulaniciSoyad,KulaniciSifre) values (@p1,@p2,@p3,@p4)", Baglanti);
            komut.Parameters.AddWithValue("@p1", textTC.Text);
            komut.Parameters.AddWithValue("@p2", textAd.Text);
            komut.Parameters.AddWithValue("@p3", textSoyad.Text);
            komut.Parameters.AddWithValue("@p4", textSifre.Text);
            komut.ExecuteNonQuery();
            Baglanti.Close();
            MessageBox.Show("Kaydınız Yapıldı.");


        }
    }
}
