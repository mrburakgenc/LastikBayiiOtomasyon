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
    public partial class lastikdepo : Form
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=bayiotomasyon;Integrated Security=True;MultipleActiveResultSets=True");
        public string sorgu;
        public string sorgu1;
        public string sorgu2;
        public SqlDataReader oku;
        public SqlCommand komut;
        public SqlCommand komut2;
        public SqlDataAdapter listele;
        public lastikdepo()
        {
            InitializeComponent();
        }

        private void lastikdepo_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lastikdepoislemler lastikdepoislemler = new lastikdepoislemler();
            lastikdepoislemler.Show();
        }
    }
}
