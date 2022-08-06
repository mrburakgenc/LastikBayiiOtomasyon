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
    public partial class lastikdepoislemler : Form
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=bayiotomasyon;Integrated Security=True;MultipleActiveResultSets=True");
        public string sorgu;
        public string sorgu1;
        public string sorgu2;
        public string sorgu3;
        public string sorgu4;
        public string sorgu5;
        public string sorguraf;
        public int islemrafno;
        public SqlDataReader oku;
        public SqlCommand komut;
        public SqlCommand komut2;
        public SqlDataAdapter listele;
        public string cpuserino;
        public string tip = "Lastik Depo Kayıt Ekleme";
        public string tip2 = "Lastik Depo Kayıt Silme";
        public DateTime tarih = DateTime.Now;
        public lastikdepoislemler()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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


        private void lastikdepoislemler_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            panel1.Visible = false;
            dataGridView1.Visible = false;
            panel3.Visible = false;
            try
            {
                baglanti.Open();
                DataTable dtb = new DataTable();
                listele = new SqlDataAdapter("select * from lastikdepo", baglanti);
                listele.Fill(dtb);
                dataGridView1.DataSource = dtb;
                dataGridView1.Columns[0].HeaderCell.Value = "Kayıt Numarası";
                dataGridView1.Columns[1].HeaderCell.Value = "Müşteri Ad Soyad";
                dataGridView1.Columns[2].HeaderCell.Value = "Müşteri Plaka";
                dataGridView1.Columns[3].HeaderCell.Value = "Müşteri Kimlik No";
                dataGridView1.Columns[4].HeaderCell.Value = "Müşteri Telefon";
                dataGridView1.Columns[5].HeaderCell.Value = "Müşteri Adres";
                dataGridView1.Columns[6].HeaderCell.Value = "Lastik Tipi";
                dataGridView1.Columns[7].HeaderCell.Value = "Adet";
                dataGridView1.Columns[8].HeaderCell.Value = "Raf Numarası";
      
                baglanti.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Hata Oluştu Kodu ..:" + error);

            }
            baglanti.Open();
            sorgu = string.Format("select rafno from deporaf where durum = 0");
            komut = new SqlCommand(sorgu,baglanti);
            oku = komut.ExecuteReader();
            if (oku.HasRows)
            {
                while (oku.Read())
                {
                    comboBox3.Items.Add(oku[0]);
                }
                oku.Close();
                baglanti.Close();

            }
            else
            {
                MessageBox.Show("Tum Alanlar Doludur !");
                oku.Close();
                baglanti.Close();

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            dataGridView1.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            sorgu2 = string.Format("insert into lastikdepo(ldmusteriadsoyad,ldmusteriplaka,ldmusteritelefon,ldmusterikimlikno,ldmusteriadres,ldlastiktipi,ldadet,ldraf)values('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+richTextBox1.Text+"','"+comboBox1.SelectedItem.ToString()+"','"+comboBox2.SelectedItem.ToString()+"','"+comboBox3.SelectedItem.ToString()+"')");
            komut = new SqlCommand(sorgu2, baglanti);
            komut.ExecuteNonQuery();
            sorguraf = string.Format("update deporaf set durum=1 where rafno="+comboBox3.SelectedItem.ToString()+"");
            komut = new SqlCommand(sorguraf, baglanti);
            komut.ExecuteNonQuery();
            cpuserino = CPUSeriNoCek().ToString();
            string sqlFormattedDate = tarih.ToString("yyyy-MM-dd HH:mm:ss.fff");
            sorgu = string.Format("insert into islemcilogu(islemciserino,islemtipi,islemtarihi)values('" + cpuserino + "','" + tip + "','" + sqlFormattedDate + "')");
            komut = new SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşlem Tamam !");
            panel1.Visible = false;
            panel2.Visible = true;
            dataGridView1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel2.Visible = false;
            dataGridView1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            sorgu3 = string.Format("select ldraf from lastikdepo where ldno="+textBox5.Text+"");
            komut = new SqlCommand(sorgu3,baglanti);
            oku = komut.ExecuteReader();
            oku.Read();
            islemrafno = Convert.ToInt32(oku[0]);
            oku.Close();
            sorgu4 = string.Format("update deporaf set durum = 0 where rafno="+islemrafno+"");
            komut = new SqlCommand(sorgu4, baglanti);
            komut.ExecuteNonQuery();
            sorgu5 = string.Format("delete from lastikdepo where ldno=" + textBox5.Text + "");
            komut = new SqlCommand(sorgu5,baglanti);
            komut.ExecuteNonQuery();
            cpuserino = CPUSeriNoCek().ToString();
            string sqlFormattedDate = tarih.ToString("yyyy-MM-dd HH:mm:ss.fff");
            sorgu = string.Format("insert into islemcilogu(islemciserino,islemtipi,islemtarihi)values('" + cpuserino + "','" + tip2 + "','" + sqlFormattedDate + "')");
            komut = new SqlCommand(sorgu, baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("İşlem Tamam !!");
            panel3.Visible = false;
            dataGridView1.Visible = false;
            panel2.Visible = true;
        }
    }
}
