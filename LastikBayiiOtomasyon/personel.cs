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
    public partial class personel : Form
    {
        public SqlConnection baglanti = new SqlConnection("Data Source=.;Initial Catalog=bayiotomasyon;Integrated Security=True;MultipleActiveResultSets=True");
        public string sorgu;
        public string sorgu1;
        public SqlDataReader oku; 
        public SqlCommand komut;
        public SqlDataAdapter listele;

        public personel()
        {
            InitializeComponent();
        }

        private void personel_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
            try
            {
                baglanti.Open();
                DataTable dtb = new DataTable();
                listele = new SqlDataAdapter("select * from personel", baglanti);
                listele.Fill(dtb);
                dataGridView1.DataSource = dtb;
                dataGridView1.Columns[0].HeaderCell.Value = "Personel Kimlik No";
                dataGridView1.Columns[1].HeaderCell.Value = "Ad Soyad";
                dataGridView1.Columns[2].HeaderCell.Value = "Personel Tipi";
                dataGridView1.Columns[3].HeaderCell.Value = "Personel Adresi";
                dataGridView1.Columns[4].HeaderCell.Value = "Personel IBAN";
                dataGridView1.Columns[5].HeaderCell.Value = "Personel Telefon";
                dataGridView1.Columns[6].HeaderCell.Value = "Personel Kullanıcı ADI";
                dataGridView1.Columns[7].HeaderCell.Value = "Personel Şifre";
      
                baglanti.Close();
               
            }
            catch (Exception error)
            {

                MessageBox.Show("Hata Oluştu Kodu ..:" + error);

            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            personelekle personelekle = new personelekle();
            personelekle.Show();
        }

        private void personelsil_Click(object sender, EventArgs e)
        {
            personelsil personelsil = new personelsil();
            personelsil.Show();

        }

        private void personelguncelle_Click(object sender, EventArgs e)
        {
            personelguncelle personelguncelle = new personelguncelle();
            personelguncelle.Show();
        }
    }
}
