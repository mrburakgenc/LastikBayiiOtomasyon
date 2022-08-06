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
    public partial class lastikdepologin : Form
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=bayiotomasyon;Integrated Security=True;MultipleActiveResultSets=True");
        public SqlCommand komut;
        public SqlDataReader oku;
        public string sorgu;
        public string cpuserino;
        public string tip = "Lastik Depo Giriş";
        public DateTime tarih = DateTime.Now;

        public lastikdepologin()
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

        private void lastikdepologin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            if (textBox1.Text != "" || textBox2.Text != "")
            {
                sorgu = string.Format("select * from personel where personelkadi='" + textBox1.Text + "' and personelsifre='" + textBox2.Text + "' and personeltipi='Depo Sorumlusu'");
                komut = new SqlCommand(sorgu, baglanti);
                oku = komut.ExecuteReader();
                if (oku.HasRows)
                {
                    cpuserino = CPUSeriNoCek().ToString();
                    string sqlFormattedDate = tarih.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    sorgu = string.Format("insert into islemcilogu(islemciserino,islemtipi,islemtarihi)values('" + cpuserino + "','" + tip + "','" + sqlFormattedDate + "')");
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("İşlem Başarılı Yönlendiriliyorsunuz.");
                    lastikdepo lastikdepo = new lastikdepo();
                    lastikdepo.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Bilgileri Kontrol Edin.");
                }
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Boşluk Bırakmayın..");
            }

        }
    }
}
