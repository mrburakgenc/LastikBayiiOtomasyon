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
    public partial class urunekle : Form
    {
        public urunekle()
        {
            InitializeComponent();
        }
        public SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=bayiotomasyon;Integrated Security=True;MultipleActiveResultSets=True");
        public string sorgu;
        public string sorgu1;
        public SqlDataReader oku;
        public SqlCommand komut;
        public string tip;
        public string ebat;
        public string cpuserino;
        public string type = "Ürün Ekleme";
        public DateTime tarih = DateTime.Now;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox1.Text == null || textBox2.Text == null || maskedTextBox1.Text == null || textBox4.Text == null || textBox5.Text == null || comboBox1.SelectedText == null)           
                {
                    MessageBox.Show(" Boş Alan Bırakmayınız...! ");
                }
                else
	            {
                  baglanti.Open();
                  if (checkBox1.Checked == true)
                  {
                      ebat = "Standart";
                  }
                  else
                  {
                      ebat = maskedTextBox1.Text.ToString();
                  }
                  sorgu = string.Format("insert into stok(surunkodu,surunadi,suruntipi,surunebati,surunadet,suruntutar,surunmarka) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + ebat + "','" + textBox4.Text + "','" + textBox5.Text + "','"+comboBox2.SelectedItem.ToString()+"')");
                  komut = new SqlCommand(sorgu, baglanti);
                  komut.ExecuteNonQuery();
                  cpuserino = CPUSeriNoCek().ToString();
                  string sqlFormattedDate = tarih.ToString("yyyy-MM-dd HH:mm:ss.fff");
                  sorgu = string.Format("insert into islemcilogu(islemciserino,islemtipi,islemtarihi)values('" + cpuserino + "','" + type + "','" + sqlFormattedDate + "')");
                  komut = new SqlCommand(sorgu, baglanti);
                  komut.ExecuteNonQuery();
                  MessageBox.Show("İşlem Tamam .. ");
                  baglanti.Close();
	            } 

            }
            catch (Exception hata)
            {

                MessageBox.Show("Girilen Değerlere Dikkat Edin..");
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


        private void urunekle_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            maskedTextBox1.Mask = "###\\/##\\/##";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                maskedTextBox1.Visible = false;
            }
            else
            {
                maskedTextBox1.Visible = true;
            }
        }
    }
}
