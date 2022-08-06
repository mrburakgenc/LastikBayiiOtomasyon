using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Management;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace LastikBayiiOtomasyon
{
    public partial class gerialinan : Form
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=bayiotomasyon;Integrated Security=True;MultipleActiveResultSets=True");
        public string sorgu;
        public string sorgu1;
        public string sorgu3;
        public string sorgu4;
        public string sorgu5;
        public string sorgu6;
        public int kayitsayisi;
        public SqlDataReader oku;
        public SqlCommand komut;
        public SqlDataAdapter listele;
        public SqlDataAdapter listele2;
        public string cpuserino;
        public string tip = "Ürün Geri Alma";
        public DateTime tarih = DateTime.Now;
        public gerialinan()
        {
            InitializeComponent();
        }
        public static String CPUSeriNoCek()
        {
            String processorID = "";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * FROM WIN32_Processor");
            ManagementObjectCollection mObject = searcher.Get();

            foreach (ManagementObject obj in mObject)
            {
                processorID = obj["ProcessorId"].ToString();
            }

            return processorID;
        }

        private void gerialinan_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            try
            {
                baglanti.Open();
                DataTable dtb = new DataTable();
                listele = new SqlDataAdapter("select * from satilan", baglanti);
                listele.Fill(dtb);
                dataGridView1.DataSource = dtb;
                dataGridView1.Columns[0].HeaderCell.Value = "Numara";
                dataGridView1.Columns[1].HeaderCell.Value = "Ad Soyad";
                dataGridView1.Columns[2].HeaderCell.Value = "Ürün";
                dataGridView1.Columns[3].HeaderCell.Value = "Ürün Adı";
                dataGridView1.Columns[4].HeaderCell.Value = "Ürün Ebatı";
                dataGridView1.Columns[5].HeaderCell.Value = "Tarih";
                dataGridView1.Columns[6].HeaderCell.Value = "Ürün Marka";
                dataGridView1.Columns[7].HeaderCell.Value = "Ürün Adet";
                baglanti.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Hata Oluştu Kodu ..:" + error);

            }
            try
            {
                baglanti.Open();
                DataTable dtb2 = new DataTable();
                listele2 = new SqlDataAdapter("select * from gerialinan", baglanti);
                listele2.Fill(dtb2);
                dataGridView2.DataSource = dtb2;
                dataGridView2.Columns[0].HeaderCell.Value = "Kayıt Numarası";
                dataGridView2.Columns[1].HeaderCell.Value = "Müşteri Ad Soyad";
                dataGridView2.Columns[2].HeaderCell.Value = "Ürün Tipi";
                dataGridView2.Columns[3].HeaderCell.Value = "Ürün Adı";
                dataGridView2.Columns[4].HeaderCell.Value = "Ürün Ebatı";
                dataGridView2.Columns[5].HeaderCell.Value = "Geri Alma Nedeni";
                dataGridView2.Columns[6].HeaderCell.Value = "Tarih";
                dataGridView2.Columns[7].HeaderCell.Value = "Ürün Marka";
                dataGridView2.Columns[8].HeaderCell.Value = "Ürün Adet";
                baglanti.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Hata Oluştu Kodu ..:" + error);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || richTextBox1.Text == null)
            {
                MessageBox.Show("Gerekli Alanları Doldurun !!");
            }
            else
            {
                baglanti.Open();
                sorgu = string.Format("select sno from satilan where sno="+textBox1.Text+"");
                komut = new SqlCommand(sorgu, baglanti);
                oku = komut.ExecuteReader();
                if (oku.HasRows)
                {
                    cpuserino = CPUSeriNoCek().ToString();
                    string sqlFormattedDate = tarih.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    sorgu = string.Format("insert into islemcilogu(islemciserino,islemtipi,islemtarihi)values('" + cpuserino + "','" + tip + "','" + sqlFormattedDate + "')");
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.ExecuteNonQuery();
                   sorgu1 = string.Format("insert into gerialinan(gmusteriadsoyad,gurun,gurunadi,gurunebati,gtarih,surunmarka,surunadet) select satilan.smusteriadsoyad,satilan.surun,satilan.surunadi,satilan.surunebati,satilan.starih,satilan.surunmarka,satilan.surunadet from satilan where sno="+textBox1.Text+"");
                   komut = new SqlCommand(sorgu1, baglanti);
                   komut.ExecuteNonQuery();
                   sorgu3 = string.Format("select count(*) from gerialinan");
                   komut = new SqlCommand(sorgu3, baglanti);
                   oku = komut.ExecuteReader();
                   oku.Read();
                   kayitsayisi = Convert.ToInt32(oku[0]);
                   oku.Close();
                   sorgu4 = string.Format("update gerialinan set gnedeni='"+richTextBox1.Text+"' where gno="+kayitsayisi+"");
                   komut = new SqlCommand(sorgu4, baglanti);
                   komut.ExecuteNonQuery();
                   sorgu5 = string.Format("delete from satilan where sno=" + textBox1.Text + "");
                   komut = new SqlCommand(sorgu5, baglanti);
                   komut.ExecuteNonQuery();
                   MessageBox.Show("İşlem Tamam !");
                   baglanti.Close();
                }
                else
                {
                    MessageBox.Show("Girilen Numara Yanlıs !!!");
                    baglanti.Close();
                }
            }
        }
    }
}
