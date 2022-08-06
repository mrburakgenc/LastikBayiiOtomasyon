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
    public partial class satilan : Form
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=bayiotomasyon;Integrated Security=True;MultipleActiveResultSets=True");
        public string sorgu;
        public string sorgu1;
        public SqlDataReader oku;
        public SqlCommand komut;
        public SqlDataAdapter listele;

        public satilan()
        {
            InitializeComponent();
        }

        private void satilan_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            try
            {
                baglanti.Open();
                DataTable dtb = new DataTable();
                listele = new SqlDataAdapter("select * from satilan", baglanti);
                listele.Fill(dtb);
                dataGridView1.DataSource = dtb;
                dataGridView1.Columns[0].HeaderCell.Value = "Numara";
                dataGridView1.Columns[1].HeaderCell.Value = "Ad Soyad";
                dataGridView1.Columns[2].HeaderCell.Value = "Ürün";
                dataGridView1.Columns[3].HeaderCell.Value = "Ürün Adı";
                dataGridView1.Columns[4].HeaderCell.Value = "Ürün Ebatı";
                dataGridView1.Columns[5].HeaderCell.Value = "Tarih";
                dataGridView1.Columns[6].HeaderCell.Value = "Ürün Marka";
                dataGridView1.Columns[7].HeaderCell.Value = "Ürün Adet";
                baglanti.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Hata Oluştu Kodu ..:" + error);

            }
        }
    }
}
