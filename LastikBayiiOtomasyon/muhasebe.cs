using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LastikBayiiOtomasyon
{
    public partial class muhasebe : Form
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=bayiotomasyon;Integrated Security=True;MultipleActiveResultSets=True");
        public string sorgu;
        public string sorgu1;
        public string sorgu2;
        public string sorgu3;
        public double total,total2;
        public SqlDataReader oku;
        public SqlCommand komut;
        public SqlCommand komut2;
        public SqlDataAdapter listele;
        public muhasebe()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                baglanti.Open();
                DataTable dtb = new DataTable();
                SqlCommand kmt2 = new SqlCommand("select * from muhasebe where mislemtarihi between @Tarih1 and @Tarih2", baglanti);
                kmt2.Parameters.AddWithValue("@Tarih1", dateTimePicker1.Value.Date.ToString("yyyy-MM-dd HH:mm:ss.fff"));
                kmt2.Parameters.AddWithValue("@Tarih2", dateTimePicker2.Value.Date.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss.fff"));
                listele = new SqlDataAdapter(kmt2);
                listele.Fill(dtb);
                dataGridView1.DataSource = dtb;
                dataGridView1.Columns[0].HeaderCell.Value = "İşlem Numarası";
                dataGridView1.Columns[1].HeaderCell.Value = "Yapılan İşlem";
                dataGridView1.Columns[2].HeaderCell.Value = "Kazanç";
                dataGridView1.Columns[3].HeaderCell.Value = "İşlem Yapan";
                dataGridView1.Columns[4].HeaderCell.Value = "İşlem Tarihi";               

                SqlCommand kmt3 = new SqlCommand("select mkazanc from muhasebe where mislemtarihi between @uTarih1 and @uTarih2", baglanti);
                kmt3.Parameters.AddWithValue("@uTarih1", dateTimePicker1.Value.Date);
                kmt3.Parameters.AddWithValue("@uTarih2", dateTimePicker2.Value.Date.AddDays(1));
                oku =kmt3.ExecuteReader();
                if (oku.HasRows)
                {
                    while (oku.Read())
                    {
                        
                        total = Convert.ToDouble(oku[0]);
                        total2 = total2 + total;
                    }
                    label4.Text = total2.ToString()+" TL";
                    oku.Close();
                    baglanti.Close();
                }
                else
                {
                    MessageBox.Show("Bu Aralıklarda Kayıt Bulunamadı ..");
                    oku.Close();
                    baglanti.Close();
                }
                
            }
            catch (Exception error)
            {

                MessageBox.Show("Hata Oluştu Kodu ..:" + error);

            }
        }

        private void muhasebe_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }
    }
}
