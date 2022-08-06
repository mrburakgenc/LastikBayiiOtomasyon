namespace LastikBayiiOtomasyon
{
    partial class personel
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.personelsil = new System.Windows.Forms.Button();
            this.personelguncelle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(861, 282);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 344);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 49);
            this.button1.TabIndex = 1;
            this.button1.Text = "Personel Ekle";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // personelsil
            // 
            this.personelsil.Location = new System.Drawing.Point(376, 344);
            this.personelsil.Name = "personelsil";
            this.personelsil.Size = new System.Drawing.Size(95, 49);
            this.personelsil.TabIndex = 2;
            this.personelsil.Text = "Personel Sil";
            this.personelsil.UseVisualStyleBackColor = true;
            this.personelsil.Click += new System.EventHandler(this.personelsil_Click);
            // 
            // personelguncelle
            // 
            this.personelguncelle.Location = new System.Drawing.Point(554, 344);
            this.personelguncelle.Name = "personelguncelle";
            this.personelguncelle.Size = new System.Drawing.Size(86, 49);
            this.personelguncelle.TabIndex = 3;
            this.personelguncelle.Text = "Personel Güncelle";
            this.personelguncelle.UseVisualStyleBackColor = true;
            this.personelguncelle.Click += new System.EventHandler(this.personelguncelle_Click);
            // 
            // personel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 422);
            this.Controls.Add(this.personelguncelle);
            this.Controls.Add(this.personelsil);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "personel";
            this.Text = "Personel / Lastik Bayii Otomasyon / Author : Burak GENÇ";
            this.Load += new System.EventHandler(this.personel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button personelsil;
        private System.Windows.Forms.Button personelguncelle;
    }
}