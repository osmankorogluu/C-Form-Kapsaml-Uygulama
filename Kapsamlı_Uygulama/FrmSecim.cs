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
    public partial class FrmSecim : Form
    {
        public FrmSecim()
        {
            InitializeComponent();
        }
        SqlConnection Baglanti = new SqlConnection("Data Source=.;Initial Catalog=Buyuk_Proje;Integrated Security=True");

        private void button1_Click(object sender, EventArgs e)
        {
            Baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Secim (ULKEAD,Micrasoft,Amazon,Monster,Asus,Xiaomi,Vestel,Arçelik) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", Baglanti);
            komut.Parameters.AddWithValue("@p1", textUlkeAD.Text);
            komut.Parameters.AddWithValue("@p2", textMicrasoft.Text);
            komut.Parameters.AddWithValue("@p3", textAmazon.Text);
            komut.Parameters.AddWithValue("@p4", textMonster.Text);
            komut.Parameters.AddWithValue("@p5", textAsus.Text);
            komut.Parameters.AddWithValue("@p6", textXiaomi.Text);
            komut.Parameters.AddWithValue("@p7", textVestel.Text);
            komut.Parameters.AddWithValue("@p8", textArcelik.Text);
            komut.ExecuteNonQuery();
            Baglanti.Close();
            MessageBox.Show("Oylama Yapılmıştır.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmSecimGrafik frm = new FrmSecimGrafik();
            frm.Show();
            this.Hide();
        }

        private void FrmSecim_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}