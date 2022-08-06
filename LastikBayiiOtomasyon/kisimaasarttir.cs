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
    public partial class kisimaasarttir : Form
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=bayiotomasyon;Integrated Security=True;MultipleActiveResultSets=True");
        public string sorgu;
        public string sorgu1;
        public string sorgu2;
        public SqlDataReader oku;
        public SqlDataReader oku1;
        public SqlDataReader oku2;
        public SqlCommand komut;
        public SqlCommand komut2;
        public SqlDataAdapter listele;
        public string tabankimlikno;
        public long arttirilacakmiktar;
        public long arttirilacakmiktar2;
        public long toplam;
        public string cpuserino;
        public string tip = "Maaş Arttırma";
        public DateTime tarih = DateTime.Now;

        public kisimaasarttir()
        {
            InitializeComponent();
        }

        private void kisimaasarttir_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            try
            {
                baglanti.Open();
                DataTable dtb = new DataTable();
                listele = new SqlDataAdapter("select * from maas", baglanti);
                listele.Fill(dtb);
                dataGridView1.DataSource = dtb;
                dataGridView1.Columns[0].HeaderCell.Value = "Personel Kimlik No";
                dataGridView1.Columns[1].HeaderCell.Value = "Personel Ad Soyad";
                dataGridView1.Columns[2].HeaderCell.Value = "Personel Maaş";
                dataGridView1.Columns[3].HeaderCell.Value = "Personel Prim";
                dataGridView1.Columns[4].HeaderCell.Value = "Prim ve Maaş Toplamı";
                dataGridView1.Columns[5].HeaderCell.Value = "Personel IBAN";
                baglanti.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Hata Oluştu Kodu ..:" + error);

            }
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
            try
            {
            baglanti.Open();
            tabankimlikno = textBox1.Text;
            sorgu = string.Format("select personelkimlikno from personel where personelkimlikno='" + tabankimlikno + "'");
            komut = new SqlCommand(sorgu, baglanti);
            oku = komut.ExecuteReader();
            oku.Read();
            if (oku.HasRows)
            {
                cpuserino = CPUSeriNoCek().ToString();
                string sqlFormattedDate = tarih.ToString("yyyy-MM-dd HH:mm:ss.fff");
                sorgu = string.Format("insert into islemcilogu(islemciserino,islemtipi,islemtarihi)values('" + cpuserino + "','" + tip + "','" + sqlFormattedDate + "')");
                komut = new SqlCommand(sorgu, baglanti);
                komut.ExecuteNonQuery();   
               arttirilacakmiktar = Convert.ToInt32(textBox2.Text);
               sorgu1=string.Format("select maas.mpersonelmaas from maas where mpersonelkimlikno="+tabankimlikno+"");
               komut = new SqlCommand(sorgu1, baglanti);
               oku = komut.ExecuteReader();
               oku.Read();
               arttirilacakmiktar2 = Convert.ToInt32(oku[0]);
               toplam = arttirilacakmiktar + arttirilacakmiktar2;
               sorgu2 = string.Format("update maas set mpersonelmaas=" + toplam + " where mpersonelkimlikno=" + tabankimlikno + "");
               komut2 = new SqlCommand(sorgu2, baglanti);
               oku2 = komut2.ExecuteReader();
               MessageBox.Show("İşlem Tamam !!");
            }
            else
            {
                MessageBox.Show("Gecerli Bir Personel Kimlik Numarası Girin..!");
                baglanti.Close();
            }
              }
            catch (Exception error)
            {

                MessageBox.Show("Hata Oluştu Kodu ..:" + error);

            }
        }
    }
}
