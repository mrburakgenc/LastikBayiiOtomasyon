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
    public partial class personelekle : Form
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=bayiotomasyon;Integrated Security=True;MultipleActiveResultSets=True");
        public string sorgu;
        public string sorgu1;
        public string sorgu2;
        public string sorgu3;
        public SqlDataReader oku;
        public SqlDataReader oku2;
        public SqlCommand komut;
        public string tip;
        public long para;
        public int girisprim=0;
        public string cpuserino;
        public string type = "Personel Ekleme";
        public DateTime tarih = DateTime.Now;
        public personelekle()
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


            if (textBox1.Text == null || textBox2.Text == null || radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false || textBox3.Text == null || textBox4.Text == null || textBox5.Text == null || maskedTextBox1.Text == null || richTextBox1.Text == null)
            {

                MessageBox.Show(" Boş Alan Bırakmayınız ..! ");

            }
            else
            {
                if (radioButton1.Checked==true)
	         {
		        tip="Satis Elemani";
                para = 2000;

	         }
                else if (radioButton2.Checked==true)
	         {
		        tip="Depo Sorumlusu";
                para = 1850;
	         }
                else
             {
                tip="Servis Elemani";
                para = 1300;
             }

                baglanti.Open();
                sorgu2 = string.Format("select personelkimlikno from personel where personelkimlikno='"+textBox1.Text+"'");
                komut = new SqlCommand(sorgu2,baglanti);
                oku = komut.ExecuteReader();
                sorgu3 = string.Format("select personelkadi from personel where personelkadi='" + textBox4.Text + "'");
                komut = new SqlCommand(sorgu3, baglanti);
                oku2 = komut.ExecuteReader();
                if (oku.HasRows)
                {
                    MessageBox.Show("Böyle Bir Personel Numara Kayıtlıdır..");
                    baglanti.Close();
                }
                else if (oku2.HasRows)
                {
                    MessageBox.Show("Böyle Bir Personel Kullanıcı Adı Kayıtlıdır..");
                    baglanti.Close();
                }
                else
                {
                    baglanti.Close();
                    baglanti.Open();
                    sorgu = string.Format("insert into personel(personelkimlikno,personeladsoyad,personeltipi,personeladres,personeliban,personeltelefon,personelkadi,personelsifre) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + tip + "','" + richTextBox1.Text + "','" + textBox3.Text + "','" + maskedTextBox1.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')");
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.ExecuteNonQuery();
                    sorgu1 = string.Format("insert into maas(mpersonelkimlikno,mpersoneladsoyad,mpersonelmaas,mpersonelprim,mpersoneliban) values('" + textBox1.Text + "','" + textBox2.Text + "','" + para + "',"+girisprim+",'" + textBox3.Text + "')");
                    komut = new SqlCommand(sorgu1, baglanti);
                    komut.ExecuteNonQuery();
                    cpuserino = CPUSeriNoCek().ToString();
                    string sqlFormattedDate = tarih.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    sorgu = string.Format("insert into islemcilogu(islemciserino,islemtipi,islemtarihi)values('" + cpuserino + "','" + type + "','" + sqlFormattedDate + "')");
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("İşlem Tamam !");
                    baglanti.Close();
                }
                 
            }

           }
            catch (Exception error)
            {
                MessageBox.Show("Değerleri Kontrol Ediniz...");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void personelekle_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }
    }
}
