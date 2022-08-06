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
    public partial class satis : Form
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=bayiotomasyon;Integrated Security=True;MultipleActiveResultSets=True");
        public string sorgu;
        public string sorgu1;
        public string sorgu2;
        public string sorgu3;
        public string sorgu4;
        public string sorgu5;
        public string sorgu6;
        public string sorgu7;
        public string sorgu8;
        public string sorgu9;
        public string sorgu10;
        public string sorgu11;
        public string kimlikno;
        public string sorgu12;
        public string islemtipi = "Satis";
        public int tabanfiyat,eklenecek,sonfiyat,eskiadet, degistirilecekadet, gunceladet;
        public double ptaban, peklenecek, psonuc;
        public SqlDataReader oku;
        public SqlCommand komut;
        public SqlDataAdapter listele;
        public string personeltip = "Satis Elemani";
        public DateTime simdi = DateTime.Now;
        public string cpuserino;
        public string tip = "Ürün Satışı";
        

        public satis()
        {
            InitializeComponent();
        }

        private void satis_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            try
            {
                baglanti.Open();
                DataTable dtb = new DataTable();
                listele = new SqlDataAdapter("select * from stok", baglanti);
                listele.Fill(dtb);
                dataGridView1.DataSource = dtb;
                baglanti.Close();
                dataGridView1.Columns[0].HeaderCell.Value = "Ürün Kodu";
                dataGridView1.Columns[1].HeaderCell.Value = "Ürün Adı";
                dataGridView1.Columns[2].HeaderCell.Value = "Ürün Tipi";
                dataGridView1.Columns[3].HeaderCell.Value = "Ürün Ebatı";
                dataGridView1.Columns[4].HeaderCell.Value = "Ürün Adet";
                dataGridView1.Columns[5].HeaderCell.Value = "Ürün Tutar";
                dataGridView1.Columns[6].HeaderCell.Value = "Ürün Marka";
              
            }
            catch (Exception error)
            {

                MessageBox.Show("Hata Oluştu Kodu ..:" + error);

            }
            baglanti.Open();
            satis satis = new satis();
            sorgu = string.Format("select personeladsoyad from personel where personeltipi='" + personeltip + "'");
            komut = new SqlCommand(sorgu, baglanti);
            oku = komut.ExecuteReader();
            if (oku.HasRows)
            {
                while (oku.Read())
                {
                    comboBox5.Items.Add(oku[0]);
                }
                oku.Close();
                baglanti.Close();
                

            }
            else
            {
                oku.Close();
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBox1.Text == null || comboBox2.Text == null || comboBox3.Text == null || comboBox4.Text == null || comboBox5.Text == null || comboBox6.Text == null)
            {
                MessageBox.Show("Tüm Alanları Doldurun !!!!!!!!");
            }
            else
            {
                baglanti.Open();
                sorgu3 = string.Format("select surunadet from stok where surunebati='" + comboBox4.SelectedItem.ToString() + "'");
                komut = new SqlCommand(sorgu3, baglanti);
                oku = komut.ExecuteReader();
                oku.Read();
                eskiadet = Convert.ToInt32(oku[0]);
                oku.Close();
                degistirilecekadet = Convert.ToInt32(comboBox6.SelectedItem.ToString());
                if (degistirilecekadet < eskiadet)
                {
                    string sqlFormattedDate = simdi.ToString("yyyy-MM-dd HH:mm:ss.fff");
                    cpuserino = CPUSeriNoCek().ToString();
                    sorgu = string.Format("insert into islemcilogu(islemciserino,islemtipi,islemtarihi)values('" + cpuserino + "','" + tip + "','" + sqlFormattedDate + "')");
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.ExecuteNonQuery();
                    sorgu4 = string.Format("insert into satilan (smusteriadsoyad,surun,surunadi,surunebati,starih,surunmarka,surunadet)values('" + textBox1.Text + "','" + comboBox2.SelectedItem.ToString() + "','" + comboBox3.SelectedItem.ToString() + "','" + comboBox4.SelectedItem.ToString() + "','" + sqlFormattedDate + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox6.SelectedItem.ToString() + "')");
                    komut = new SqlCommand(sorgu4, baglanti);
                    komut.ExecuteNonQuery();
                    gunceladet = eskiadet - degistirilecekadet;
                    sorgu5 = string.Format("update stok set surunadet=" + gunceladet + " where surunebati='" + comboBox4.SelectedItem.ToString() + "'");
                    komut = new SqlCommand(sorgu5, baglanti);
                    komut.ExecuteNonQuery();
                    sorgu8 = string.Format("select mpersonelprim from maas where mpersonelkimlikno='" + kimlikno + "'");
                    komut = new SqlCommand(sorgu8, baglanti);
                    oku = komut.ExecuteReader();
                    oku.Read();
                    ptaban = Convert.ToDouble(oku[0]);
                    oku.Close();
                    peklenecek = (double)(sonfiyat * 2) / 100;
                    psonuc = ptaban + peklenecek;
                    sorgu9 = string.Format("update maas set mpersonelprim='" + psonuc + "' where mpersonelkimlikno='" + kimlikno + "'");
                    komut = new SqlCommand(sorgu9, baglanti);
                    komut.ExecuteNonQuery();
                    sorgu10 = string.Format("insert into muhasebe(myapilanislem,mkazanc,mislemkimin,mislemtarihi)values('" + islemtipi + "'," + sonfiyat + ",'" + comboBox5.SelectedItem.ToString() + "','" + sqlFormattedDate+ "')");
                    komut = new SqlCommand(sorgu10, baglanti);
                    komut.ExecuteNonQuery();
                    MessageBox.Show("İşlem Tamam !");
                    baglanti.Close();

                }
                else
                {
                    MessageBox.Show("Yeterli Miktarda Urun Yoktur !!!");
                    oku.Close();
                    baglanti.Close();

                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            sorgu1 = string.Format("select surunadi from stok where surunmarka='"+comboBox1.SelectedItem.ToString()+"' and suruntipi='"+comboBox2.SelectedItem.ToString()+"'");
            komut = new SqlCommand(sorgu1,baglanti);
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
                MessageBox.Show("Kayıtlı Ürün Yoktur !!");
                oku.Close();
                baglanti.Close();
            }
            
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            sorgu2 = string.Format("select surunebati from stok where surunadi='" + comboBox3.SelectedItem.ToString() + "'");
            komut = new SqlCommand(sorgu2, baglanti);
            oku = komut.ExecuteReader();
            if (oku.HasRows)
            {
                while (oku.Read())
                {
                    comboBox4.Items.Add(oku[0]);
                }
                oku.Close();
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Kayıtlı Ürün Yoktur !!");
                oku.Close();
                baglanti.Close();
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            sorgu6 = string.Format("select mpersonelkimlikno from maas where mpersoneladsoyad='" + comboBox5.SelectedItem.ToString() + "'");
            komut = new SqlCommand(sorgu6, baglanti);
            oku = komut.ExecuteReader();
            oku.Read();
            kimlikno = oku[0].ToString();
            oku.Close();
            baglanti.Close();
        
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            sorgu7 = string.Format("select suruntutar from stok where surunebati='"+comboBox4.SelectedItem.ToString()+"'");
            komut = new SqlCommand(sorgu7,baglanti);
            oku = komut.ExecuteReader();
            oku.Read();
            label9.Text = Convert.ToString(oku[0]);
            tabanfiyat = Convert.ToInt32(oku[0]);
            oku.Close();
            baglanti.Close();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            eklenecek = Convert.ToInt32(comboBox6.SelectedItem.ToString());
            sonfiyat = tabanfiyat * eklenecek;
            label9.Text = sonfiyat.ToString()+" TL";
        }
    }
}
