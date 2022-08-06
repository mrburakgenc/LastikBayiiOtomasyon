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
    public partial class personelguncelle : Form
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=bayiotomasyon;Integrated Security=True;MultipleActiveResultSets=True");
        public string sorgu;
        public string sorgu1;
        public SqlDataReader oku;
        public SqlCommand komut;
        public SqlDataAdapter listele;
        public string tabankimlikno;
        public string tip;
        public long para;
        public string cpuserino;
        public string type = "Personel Güncelleme";
        public DateTime tarih = DateTime.Now;
        public personelguncelle()
        {
            InitializeComponent();
        }

        private void personelguncelle_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            panel1.Visible = false;
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
                tabankimlikno = textBox3.Text;
                sorgu = string.Format("select personelkimlikno from personel where personelkimlikno='" + tabankimlikno + "'");
                komut = new SqlCommand(sorgu, baglanti);
                oku = komut.ExecuteReader();
                oku.Read();
                if (oku.HasRows)
                {
                    panel1.Visible = true;
                    textBox3.Visible = false;
                    button1.Visible = false;
                    baglanti.Close();
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

        private void kaydet_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || textBox2.Text == null || radioButton1.Checked == false && radioButton2.Checked == false && radioButton3.Checked == false || textBox4.Text == null || maskedTextBox1.Text == null || richTextBox1.Text == null || textBox5.Text == null || textBox6.Text == null)
            {

                MessageBox.Show(" Boş Alan Bırakmayınız ..! ");

            }
            else
            {
                if (radioButton1.Checked == true)
                {
                    tip = "Satis Elemani";
                    para = 2000;

                }
                else if (radioButton2.Checked == true)
                {
                    tip = "Depo Sorumlusu";
                    para = 1850;
                }
                else
                {
                    tip = "Servis Elemanı";
                    para = 1300;
                }

                baglanti.Open();
                sorgu = string.Format("update personel set personelkimlikno='" + textBox1.Text + "',personeladsoyad='" + textBox2.Text + "',personeltipi='" + tip + "',personeladres='" + richTextBox1.Text + "',personeliban='" + textBox4.Text + "',personeltelefon='" + maskedTextBox1.Text + "',personelkadi='" + textBox5.Text + "',personelsifre='" + textBox6.Text + "' where personelkimlikno='" + tabankimlikno + "'");
                komut = new SqlCommand(sorgu, baglanti);
                komut.ExecuteNonQuery();
                sorgu1 = string.Format("update maas set mpersonelkimlikno='" + textBox1.Text + "',mpersoneladsoyad='" + textBox2.Text + "',mpersonelmaas='" + para + "',mpersoneliban='" + textBox4.Text + "' where mpersonelkimlikno='" + tabankimlikno + "'");
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
}
