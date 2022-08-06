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
    public partial class personelsil : Form
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=bayiotomasyon;Integrated Security=True;MultipleActiveResultSets=True"); public string sorgu;
        public string sorgu1;
        public string sorgu2;
        public SqlDataReader oku;
        public SqlCommand komut;
        public SqlDataAdapter listele;
        public string cpuserino;
        public string tip = "Personel Sil";
        public DateTime tarih = DateTime.Now;


        public personelsil()
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

        private void button1_Click(object sender, EventArgs e)
        {
            try
        {
            baglanti.Open();

            sorgu2 = string.Format("select personelkimlikno from personel where personelkimlikno='"+textBox1.Text+"'");
            komut = new SqlCommand(sorgu2, baglanti);
            oku = komut.ExecuteReader();
            if (oku.HasRows)
            {
                cpuserino = CPUSeriNoCek().ToString();
                string sqlFormattedDate = tarih.ToString("yyyy-MM-dd HH:mm:ss.fff");
                sorgu = string.Format("insert into islemcilogu(islemciserino,islemtipi,islemtarihi)values('" + cpuserino + "','" + tip + "','" + sqlFormattedDate + "')");
                komut = new SqlCommand(sorgu, baglanti);
                komut.ExecuteNonQuery();
                sorgu = string.Format("Delete from personel where personelkimlikno='" + textBox1.Text + "'");
                komut = new SqlCommand(sorgu, baglanti);
                komut.ExecuteNonQuery();
                sorgu = string.Format("Delete from maas where mpersonelkimlikno='" + textBox1.Text + "'");
                komut = new SqlCommand(sorgu, baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("İşlem Tamam !");
                baglanti.Close();

            }
            else
            {

                MessageBox.Show("Böyle Bir Personel Kimlik No Yoktur .. !");
                baglanti.Close();
            
            }

            
        }
            catch (Exception error)
            {

                MessageBox.Show("Hata Oluştu Kodu ..:" + error);

            }

        }

        private void personelsil_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            try
            {
                baglanti.Open();
                DataTable dtb = new DataTable();
                listele = new SqlDataAdapter("select * from personel", baglanti);
                listele.Fill(dtb);
                dataGridView1.DataSource = dtb;
                dataGridView1.Columns[0].HeaderCell.Value = "Personel Kimlik No";
                dataGridView1.Columns[1].HeaderCell.Value = "Ad Soyad";
                dataGridView1.Columns[2].HeaderCell.Value = "Personel Tipi";
                dataGridView1.Columns[3].HeaderCell.Value = "Personel Adresi";
                dataGridView1.Columns[4].HeaderCell.Value = "Personel IBAN";
                dataGridView1.Columns[5].HeaderCell.Value = "Personel Telefon";
                dataGridView1.Columns[6].HeaderCell.Value = "Personel Kullanıcı ADI";
                dataGridView1.Columns[7].HeaderCell.Value = "Personel Şifre";
      
                baglanti.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Hata Oluştu Kodu ..:" + error);

            }
        }
    }
}
