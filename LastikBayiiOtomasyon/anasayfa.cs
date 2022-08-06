using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LastikBayiiOtomasyon
{
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }

        private void Personel_Click(object sender, EventArgs e)
        {
            personellogin personellogin = new personellogin();
            personellogin.Show();
        }

        private void Stok_Click(object sender, EventArgs e)
        {
            stoklogin stoklogin = new stoklogin();
            stoklogin.Show();
        }

        private void Satilan_Click(object sender, EventArgs e)
        {
            islemkayitlarilogin islemkayitlarilogin = new islemkayitlarilogin();
            islemkayitlarilogin.Show();
        }

        private void muhasebe_Click(object sender, EventArgs e)
        {
            
            muhasebelogin muhasebelogin = new muhasebelogin();
            muhasebelogin.Show();
        }

        private void satis_Click(object sender, EventArgs e)
        {
            satislogin satislogin = new satislogin();
            satislogin.Show();
        }

        private void gerialinan_Click(object sender, EventArgs e)
        {
            gerialinanlogin gerialinanlogin = new gerialinanlogin();
            gerialinanlogin.Show();

        }

        private void maas_Click(object sender, EventArgs e)
        {
            maaslogin maaslogin = new maaslogin();
            maaslogin.Show();

        }

        private void lastikdepo_Click(object sender, EventArgs e)
        {
            lastikdepologin lastikdepologin = new lastikdepologin();
            lastikdepologin.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            servislogin servislogin = new servislogin();
            servislogin.Show();
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }
    }
}
