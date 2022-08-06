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
    public partial class maas : Form
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=bayiotomasyon;Integrated Security=True;MultipleActiveResultSets=True");
        public string sorgu;
        public string sorgu1;
        public string sorgu2;
        public string sorgu3;
        public string sorgu4;
        public double tabanmaas, tabanprim, tabantoplam;
        public string kimlikno;
        public SqlDataReader oku;
        public SqlDataReader oku2;
        public SqlDataReader oku3;
        public SqlCommand komut;
        public SqlCommand komut2;
        public SqlCommand komut3;
        public SqlCommand komut4;
        public SqlCommand komut5;
        public SqlDataAdapter listele;
        public string cpuserino;
        public string tip = "Prim Toplama";
        public DateTime tarih = DateTime.Now;


        public maas()
        {
            InitializeComponent();
        }

        private void maas_Load(object sender, EventArgs e)
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
            kisimaasarttir kisimaasarttir = new kisimaasarttir();
            kisimaasarttir.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            sorgu = string.Format("select mpersonelmaas from maas");
            komut = new SqlCommand(sorgu, baglanti);
            oku = komut.ExecuteReader();
            

           
            sorgu1 = string.Format("select mpersonelprim from maas");
            komut2 = new SqlCommand(sorgu1, baglanti);
            oku2 = komut2.ExecuteReader();
          

            
            sorgu2 = string.Format("select mpersonelkimlikno from maas");
            komut3 = new SqlCommand(sorgu2, baglanti);
            oku3 = komut3.ExecuteReader();

            cpuserino = CPUSeriNoCek().ToString();
            string sqlFormattedDate = tarih.ToString("yyyy-MM-dd HH:mm:ss.fff");
            sorgu = string.Format("insert into islemcilogu(islemciserino,islemtipi,islemtarihi)values('" + cpuserino + "','" + tip + "','" + sqlFormattedDate + "')");
            komut = new SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            
            if (oku.HasRows && oku2.HasRows)
            {
                while (oku.Read() && oku3.Read()&&oku2.Read())
                {
                    tabanmaas = Convert.ToDouble(oku[0]);
                    tabanprim = Convert.ToDouble(oku2[0]);
                    kimlikno = Convert.ToString(oku3[0]);
                    tabantoplam = tabanmaas + tabanprim;
                    sorgu3 = string.Format("update maas set mpersoneltoplam ='" + tabantoplam + "' where mpersonelkimlikno='" + kimlikno + "'");
                    komut4 = new SqlCommand(sorgu3, baglanti);
                    komut4.ExecuteNonQuery();
                    sorgu4 = string.Format("update maas set mpersonelprim=0 where mpersonelkimlikno='" + kimlikno + "'");
                    komut5 = new SqlCommand(sorgu4, baglanti);
                    komut5.ExecuteNonQuery();
                }
                MessageBox.Show("İşlem Tamam");
                oku.Close();
                oku2.Close();
                oku3.Close();
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Eklenecek Prim Yoktur .. ");
                oku.Close();
                oku2.Close();
                oku3.Close();
                baglanti.Close();
 
            }
        }
    }
}
