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
    public partial class FrmKutuphane : Form
    {
        public FrmKutuphane()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=Buyuk_Proje;Integrated Security=True");

        void Listele() 
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Kutuphane1",baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        
        
        }     
        private void button1_Click(object sender, EventArgs e)
        {
            Listele();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Kaydetme işlemi.
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Tbl_Kutuphane1 (KitapAd,KitapYazar,KitapSayfa,KitapTur) values (@p1,@p2,@p3,@p4)", baglanti);
            komut.Parameters.AddWithValue("@p1", textAd.Text);
            komut.Parameters.AddWithValue("@p2", textYazar.Text);
            komut.Parameters.AddWithValue("@p3", textSayfa.Text);
            komut.Parameters.AddWithValue("@p4", comboxTur.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kitap Bilgileri Kaydedildi.");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            textKitapİD.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            textAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            textYazar.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            textSayfa.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            comboxTur.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            // amk böyle hatanın
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Silme işlemi.
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete  From Tbl_Kutuphane1 where İD=@p1", baglanti);
            komut.Parameters.AddWithValue("@p1", textKitapİD.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla Silindi.");
            Listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Güncelleme işlemi
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update Tbl_Kutuphane1 set KitapAd=@p1,KitapYazar=@p2,KitapSayfa=@p3,KitapTur=@p4 where İD=@p5", baglanti);
            komut.Parameters.AddWithValue("@p1", textAd.Text);
            komut.Parameters.AddWithValue("@p2", textYazar.Text);
            komut.Parameters.AddWithValue("@p3", textSayfa.Text);
            komut.Parameters.AddWithValue("@p4", comboxTur.Text);
            komut.Parameters.AddWithValue("@p5", textKitapİD.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Başarıyla Güncellendi.");
            Listele();
        }

        private void FrmKutuphane_Load(object sender, EventArgs e)
        {

        }
    }
}
