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
    public partial class islemkayitlari : Form
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=bayiotomasyon;Integrated Security=True;MultipleActiveResultSets=True");
        public string sorgu;
        public string sorgu1;
        public SqlDataReader oku;
        public SqlCommand komut;
        public SqlDataAdapter listele;

        public islemkayitlari()
        {
            InitializeComponent();
        }

        private void islemkayitlari_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            try
            {
                baglanti.Open();
                DataTable dtb = new DataTable();
                listele = new SqlDataAdapter("select * from islemcilogu", baglanti);
                listele.Fill(dtb);
                dataGridView1.DataSource = dtb;
                dataGridView1.Columns[0].HeaderCell.Value = "İşlemci Seri NO";
                dataGridView1.Columns[1].HeaderCell.Value = "İşlem Tipi";
                dataGridView1.Columns[2].HeaderCell.Value = "İşlem Tarihi";
                baglanti.Close();
            }
            catch (Exception error)
            {

                MessageBox.Show("Hata Oluştu Kodu ..:" + error);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            satilan satilan = new satilan();
            satilan.Show();
        }
    }
}
