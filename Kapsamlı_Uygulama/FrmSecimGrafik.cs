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
    public partial class FrmSecimGrafik : Form
    {
        public FrmSecimGrafik()
        {
            InitializeComponent();
        }
        SqlConnection Baglanti = new SqlConnection("Data Source=.;Initial Catalog=Buyuk_Proje;Integrated Security=True");

        private void FrmSecimGrafik_Load(object sender, EventArgs e)
        {
            // Comboboxa verileri Yerleştirdik.

            Baglanti.Open();
            SqlCommand komut = new SqlCommand("Select ULKEAD from Tbl_Secim", Baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            Baglanti.Close();


            //Grafik Toplam Sonuç Getirme
            Baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select SUM(Micrasoft),SUM(Amazon),SUM(Monster),SUM(Asus),SUM(Xiaomi),SUM(Vestel),SUM(Arçelik) From Tbl_Secim", Baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {


                chart1.Series["Şirketler"].Points.AddXY("Micrasoft", dr2[0]);
                chart1.Series["Şirketler"].Points.AddXY("Amazon", dr2[1]);
                chart1.Series["Şirketler"].Points.AddXY("Monster", dr2[2]);
                chart1.Series["Şirketler"].Points.AddXY("Asus", dr2[3]);
                chart1.Series["Şirketler"].Points.AddXY("Xiaomi", dr2[4]);
                chart1.Series["Şirketler"].Points.AddXY("Vestel", dr2[5]);
                chart1.Series["Şirketler"].Points.AddXY("Arçelik", dr2[6]);
            }
            Baglanti.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From Tbl_Secim where ULKEAD=@P1", Baglanti);
            komut.Parameters.AddWithValue("@p1", comboBox1.Text);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {

                progressBar2.Value = int.Parse(dr[2].ToString());
                progressBar3.Value = int.Parse(dr[3].ToString());
                progressBar4.Value = int.Parse(dr[4].ToString());
                progressBar5.Value = int.Parse(dr[5].ToString());
                progressBar6.Value = int.Parse(dr[6].ToString());
                progressBar7.Value = int.Parse(dr[7].ToString());
                progressBar8.Value = int.Parse(dr[8].ToString());

                LblMicrasoft.Text = dr[2].ToString();
                LblAmazon.Text = dr[3].ToString();
                LblMonter.Text = dr[4].ToString();
                LblAsus.Text = dr[5].ToString();
                LblXiaomi.Text= dr[6].ToString();
                LblVestel.Text = dr[7].ToString();
                labelArcelik.Text = dr[8].ToString();
            }
            Baglanti.Close();
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }
    }
}
