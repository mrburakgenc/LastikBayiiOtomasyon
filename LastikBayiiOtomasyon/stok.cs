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
    public partial class stok : Form
    {
        public stok()
        {
            InitializeComponent();
        }
        public SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=bayiotomasyon;Integrated Security=True;MultipleActiveResultSets=True");
        public string sorgu;
        public string sorgu1;
        public SqlDataReader oku;
        public SqlCommand komut;
        public SqlDataAdapter listele;

        private void stok_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            try
            {
                baglanti.Open();
                DataTable dtb = new DataTable();
                listele = new SqlDataAdapter("select * from stok", baglanti);
                listele.Fill(dtb);
                dataGridView1.DataSource = dtb;
                dataGridView1.Columns[0].HeaderCell.Value = "Ürün Kodu";
                dataGridView1.Columns[1].HeaderCell.Value = "Ürün Adı";
                dataGridView1.Columns[2].HeaderCell.Value = "Ürün Tipi";
                dataGridView1.Columns[3].HeaderCell.Value = "Ürün Ebatı";
                dataGridView1.Columns[4].HeaderCell.Value = "Adet Sayısı";
                dataGridView1.Columns[5].HeaderCell.Value = "Adet Tutarı";
                dataGridView1.Columns[6].HeaderCell.Value = "Ürün Markası";
                baglanti.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Hata Oluştu Kodu ..:" + error);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            urunguncelle yeniurun = new urunguncelle();
            yeniurun.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            urunekle urunekle = new urunekle();
            urunekle.Show();
        }
    }
}
