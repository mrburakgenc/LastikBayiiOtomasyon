namespace LastikBayiiOtomasyon
{
    partial class anasayfa
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Personel = new System.Windows.Forms.Button();
            this.Stok = new System.Windows.Forms.Button();
            this.Satilan = new System.Windows.Forms.Button();
            this.gerialinan = new System.Windows.Forms.Button();
            this.maas = new System.Windows.Forms.Button();
            this.lastikdepo = new System.Windows.Forms.Button();
            this.muhasebe = new System.Windows.Forms.Button();
            this.satis = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Personel
            // 
            this.Personel.Location = new System.Drawing.Point(121, 77);
            this.Personel.Name = "Personel";
            this.Personel.Size = new System.Drawing.Size(121, 63);
            this.Personel.TabIndex = 0;
            this.Personel.Text = "Personel";
            this.Personel.UseVisualStyleBackColor = true;
            this.Personel.Click += new System.EventHandler(this.Personel_Click);
            // 
            // Stok
            // 
            this.Stok.Location = new System.Drawing.Point(121, 146);
            this.Stok.Name = "Stok";
            this.Stok.Size = new System.Drawing.Size(121, 63);
            this.Stok.TabIndex = 1;
            this.Stok.Text = "Stok";
            this.Stok.UseVisualStyleBackColor = true;
            this.Stok.Click += new System.EventHandler(this.Stok_Click);
            // 
            // Satilan
            // 
            this.Satilan.Location = new System.Drawing.Point(121, 215);
            this.Satilan.Name = "Satilan";
            this.Satilan.Size = new System.Drawing.Size(121, 63);
            this.Satilan.TabIndex = 2;
            this.Satilan.Text = "İşlem Kayıtları";
            this.Satilan.UseVisualStyleBackColor = true;
            this.Satilan.Click += new System.EventHandler(this.Satilan_Click);
            // 
            // gerialinan
            // 
            this.gerialinan.Location = new System.Drawing.Point(663, 77);
            this.gerialinan.Name = "gerialinan";
            this.gerialinan.Size = new System.Drawing.Size(117, 63);
            this.gerialinan.TabIndex = 3;
            this.gerialinan.Text = "Geri Alınan Urunler";
            this.gerialinan.UseVisualStyleBackColor = true;
            this.gerialinan.Click += new System.EventHandler(this.gerialinan_Click);
            // 
            // maas
            // 
            this.maas.Location = new System.Drawing.Point(663, 149);
            this.maas.Name = "maas";
            this.maas.Size = new System.Drawing.Size(117, 60);
            this.maas.TabIndex = 4;
            this.maas.Text = "Maas Sistemi";
            this.maas.UseVisualStyleBackColor = true;
            this.maas.Click += new System.EventHandler(this.maas_Click);
            // 
            // lastikdepo
            // 
            this.lastikdepo.Location = new System.Drawing.Point(663, 216);
            this.lastikdepo.Name = "lastikdepo";
            this.lastikdepo.Size = new System.Drawing.Size(117, 60);
            this.lastikdepo.TabIndex = 5;
            this.lastikdepo.Text = "Lastik Depo";
            this.lastikdepo.UseVisualStyleBackColor = true;
            this.lastikdepo.Click += new System.EventHandler(this.lastikdepo_Click);
            // 
            // muhasebe
            // 
            this.muhasebe.Location = new System.Drawing.Point(257, 147);
            this.muhasebe.Name = "muhasebe";
            this.muhasebe.Size = new System.Drawing.Size(117, 60);
            this.muhasebe.TabIndex = 6;
            this.muhasebe.Text = "Muhasebe";
            this.muhasebe.UseVisualStyleBackColor = true;
            this.muhasebe.Click += new System.EventHandler(this.muhasebe_Click);
            // 
            // satis
            // 
            this.satis.Location = new System.Drawing.Point(524, 146);
            this.satis.Name = "satis";
            this.satis.Size = new System.Drawing.Size(117, 60);
            this.satis.TabIndex = 7;
            this.satis.Text = "Satış";
            this.satis.UseVisualStyleBackColor = true;
            this.satis.Click += new System.EventHandler(this.satis_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 325);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(468, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Lastik Bayii Otomasyon v1 / Author : Burak GENÇ © Tüm Hakları Belediye Çöplügünde" +
    "dir ... 2021";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(389, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 60);
            this.button1.TabIndex = 9;
            this.button1.Text = "Servis";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // anasayfa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 388);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.satis);
            this.Controls.Add(this.muhasebe);
            this.Controls.Add(this.lastikdepo);
            this.Controls.Add(this.maas);
            this.Controls.Add(this.gerialinan);
            this.Controls.Add(this.Satilan);
            this.Controls.Add(this.Stok);
            this.Controls.Add(this.Personel);
            this.Name = "anasayfa";
            this.Text = "Lastik Bayii Otomasyon / Author : Burak GENÇ";
            this.Load += new System.EventHandler(this.anasayfa_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Personel;
        private System.Windows.Forms.Button Stok;
        private System.Windows.Forms.Button Satilan;
        private System.Windows.Forms.Button gerialinan;
        private System.Windows.Forms.Button maas;
        private System.Windows.Forms.Button lastikdepo;
        private System.Windows.Forms.Button muhasebe;
        private System.Windows.Forms.Button satis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}

