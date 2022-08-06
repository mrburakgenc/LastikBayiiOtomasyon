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
    public partial class urunguncelle : Form
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=bayiotomasyon;Integrated Security=True;MultipleActiveResultSets=True");
        public string sorgu;
        public string sorgu1;
        public string sorgu2;
        public SqlDataReader oku;
        public SqlCommand komut;
        public SqlDataAdapter listele;
        public int tabanmiktar;
        public int eklenecekmiktar;
        public int toplam;
        public string cpuserino;
        public string tip = "Ürün Adet Güncelleme";
        public DateTime tarih = DateTime.Now;


        public urunguncelle()
        {
            InitializeComponent();
        }

        private void urunguncelle_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            baglanti.Open();
            DataTable dtb = new DataTable();
            listele = new SqlDataAdapter("select * from stok", baglanti);
            listele.Fill(dtb);
            dataGridView1.DataSource = dtb;
            dataGridView1.Columns[0].HeaderCell.Value = "Ürün Kodu";
            dataGridView1.Columns[1].HeaderCell.Value = "Ürün Adı";
            dataGridView1.Columns[2].HeaderCell.Value = "Ürün Tipi";
            dataGridView1.Columns[3].HeaderCell.Value = "Ürün Ebatı";
            dataGridView1.Columns[4].HeaderCell.Value = "Adet Sayısı";
            dataGridView1.Columns[5].HeaderCell.Value = "Adet Tutarı";
            dataGridView1.Columns[6].HeaderCell.Value = "Ürün Markası";
            baglanti.Close();
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
        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            sorgu = string.Format("select * from stok where surunkodu='"+textBox1.Text+"'");
            komut = new SqlCommand(sorgu, baglanti);
            oku = komut.ExecuteReader();
            if (oku.HasRows)
            {
                eklenecekmiktar = Convert.ToInt32(textBox2.Text);
                sorgu1 = string.Format("select surunadet from stok where surunkodu='" + textBox1.Text + "'");
                komut = new SqlCommand(sorgu1, baglanti);
                oku = komut.ExecuteReader();
                oku.Read();
                tabanmiktar = Convert.ToInt32(oku[0]);
                toplam = eklenecekmiktar + tabanmiktar;
                sorgu2 = string.Format("update stok set surunadet="+toplam+" where surunkodu='"+textBox1.Text+"'");
                komut = new SqlCommand(sorgu2, baglanti);
                komut.ExecuteNonQuery();
                cpuserino = CPUSeriNoCek().ToString();
                string sqlFormattedDate = tarih.ToString("yyyy-MM-dd HH:mm:ss.fff");
                sorgu = string.Format("insert into islemcilogu(islemciserino,islemtipi,islemtarihi)values('" + cpuserino + "','" + tip + "','" + sqlFormattedDate + "')");
                komut = new SqlCommand(sorgu, baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("İşlem Tamam..");
            }
            else
            {

                MessageBox.Show("Ürün Kodu Hatalı !!!");
            
            }
            baglanti.Close();
        }
    }
}
