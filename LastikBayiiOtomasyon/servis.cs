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
    public partial class servis : Form
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=bayiotomasyon;Integrated Security=True;MultipleActiveResultSets=True");
        public string sorgu;
        public string sorgu1;
        public string sorgu2;
        public string sorgu3;
        public string sorgu4;
        public string kimlikno;
        public double ucret;
        public string islemtipi = "Servis";
        public static double taban, eklenecek, sonuc;
        public DateTime simdi = DateTime.Now;
        public string cpuserino;
        public string tip = "Giriş";
        
        public string personeltip = "Servis Elemani";
        public SqlDataReader oku;
        public SqlCommand komut;
        public servis()
        {
            InitializeComponent();
        }

        private void servis_Load(object sender, EventArgs e)
        {
            
            this.MaximizeBox = false;
            baglanti.Open();
           
            sorgu1 = string.Format("select personeladsoyad from personel where personeltipi='"+personeltip+"'");
            komut = new SqlCommand(sorgu1, baglanti);
            oku = komut.ExecuteReader();
            if (oku.HasRows)
            {
                while (oku.Read())
                {
                    comboBox3.Items.Add(oku[0]);
                }
                baglanti.Close();

            }
            else
            {
                baglanti.Close();
                this.Close();
                MessageBox.Show("Servis Elemanı Yoktur !!!");
                
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


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label5.Text = "10 TL";
                ucret = 10;
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                label5.Text = "20 TL";
                ucret = 20;
            }
            else
            {

                label5.Text = "40 TL";
                ucret = 40;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null || comboBox1.Text == null || comboBox3.Text == null)
            {
                MessageBox.Show("Gerekli Alanları Doldurun !");
            }
            else
            {
                baglanti.Open();
                string sqlFormattedDate = simdi.ToString("yyyy-MM-dd HH:mm:ss.fff");
                sorgu = string.Format("insert into servis (plaka,yapilanislem,alinanucret,islemtarihi) values('" + textBox1.Text + "','" + comboBox1.SelectedItem.ToString() + "'," + ucret + ",'" + sqlFormattedDate + "')");
                komut = new SqlCommand(sorgu, baglanti);
                komut.ExecuteNonQuery();
                cpuserino = CPUSeriNoCek().ToString();
                sorgu = string.Format("insert into islemcilogu(islemciserino,islemtipi,islemtarihi)values('" + cpuserino + "','" + tip + "','" + sqlFormattedDate + "')");
                komut = new SqlCommand(sorgu, baglanti);
                komut.ExecuteNonQuery();
                sorgu1 = string.Format("select mpersonelprim from maas where mpersonelkimlikno='"+kimlikno+"'");
                komut = new SqlCommand(sorgu1,baglanti);
                oku = komut.ExecuteReader();
                oku.Read();
                taban = Convert.ToDouble(oku[0]);
                oku.Close();
                eklenecek = (double)(ucret * 2)/100;
                sonuc = taban + eklenecek;
                sorgu2 = string.Format("update maas set mpersonelprim='"+sonuc+"' where mpersonelkimlikno='"+kimlikno+"'");
                komut = new SqlCommand(sorgu2,baglanti);
                komut.ExecuteNonQuery();
                sorgu3 = string.Format("insert into muhasebe(myapilanislem,mkazanc,mislemkimin,mislemtarihi)values('" + islemtipi + "'," + ucret + ",'" + comboBox3.SelectedItem.ToString() + "','" + sqlFormattedDate + "')");
                komut = new SqlCommand(sorgu3, baglanti);
                komut.ExecuteNonQuery();
                MessageBox.Show("İşlem Tamam !");
                baglanti.Close();
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            sorgu3 = string.Format("select mpersonelkimlikno from maas where mpersoneladsoyad='"+comboBox3.SelectedItem.ToString()+"'");
            komut = new SqlCommand(sorgu3, baglanti);
            oku = komut.ExecuteReader();
            oku.Read();
            kimlikno = oku[0].ToString();
            oku.Close();
            baglanti.Close();
        }
    }
}
