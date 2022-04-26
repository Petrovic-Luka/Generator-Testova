
namespace GeneratorTestova
{
    partial class FrmPredmeti
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.cmbPredmeti = new System.Windows.Forms.ComboBox();
            this.btnIzaberi = new System.Windows.Forms.Button();
            this.btnKreirajPredmet = new System.Windows.Forms.Button();
            this.btnPitanja = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(36, 52);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(110, 33);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Predmet";
            // 
            // cmbPredmeti
            // 
            this.cmbPredmeti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPredmeti.FormattingEnabled = true;
            this.cmbPredmeti.Location = new System.Drawing.Point(42, 100);
            this.cmbPredmeti.Name = "cmbPredmeti";
            this.cmbPredmeti.Size = new System.Drawing.Size(182, 41);
            this.cmbPredmeti.TabIndex = 1;
            // 
            // btnIzaberi
            // 
            this.btnIzaberi.Location = new System.Drawing.Point(254, 93);
            this.btnIzaberi.Name = "btnIzaberi";
            this.btnIzaberi.Size = new System.Drawing.Size(132, 52);
            this.btnIzaberi.TabIndex = 2;
            this.btnIzaberi.Text = "Izaberi ";
            this.btnIzaberi.UseVisualStyleBackColor = true;
            this.btnIzaberi.Click += new System.EventHandler(this.btnIzaberi_Click);
            // 
            // btnKreirajPredmet
            // 
            this.btnKreirajPredmet.Location = new System.Drawing.Point(254, 151);
            this.btnKreirajPredmet.Name = "btnKreirajPredmet";
            this.btnKreirajPredmet.Size = new System.Drawing.Size(132, 82);
            this.btnKreirajPredmet.TabIndex = 5;
            this.btnKreirajPredmet.Text = "Kreiraj predmet";
            this.btnKreirajPredmet.UseVisualStyleBackColor = true;
            this.btnKreirajPredmet.Click += new System.EventHandler(this.btnDodajPredmet_Click);
            // 
            // btnPitanja
            // 
            this.btnPitanja.Location = new System.Drawing.Point(254, 239);
            this.btnPitanja.Name = "btnPitanja";
            this.btnPitanja.Size = new System.Drawing.Size(130, 82);
            this.btnPitanja.TabIndex = 9;
            this.btnPitanja.Text = "Azuriraj pitanja";
            this.btnPitanja.UseVisualStyleBackColor = true;
            this.btnPitanja.Click += new System.EventHandler(this.btnPitanja_Click);
            // 
            // FrmPredmeti
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(426, 649);
            this.Controls.Add(this.btnPitanja);
            this.Controls.Add(this.btnKreirajPredmet);
            this.Controls.Add(this.btnIzaberi);
            this.Controls.Add(this.cmbPredmeti);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "FrmPredmeti";
            this.Text = "Predmeti";
            this.Load += new System.EventHandler(this.FrmPredmeti_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ComboBox cmbPredmeti;
        private System.Windows.Forms.Button btnIzaberi;
        private System.Windows.Forms.Button btnKreirajPredmet;
        private System.Windows.Forms.Button btnPitanja;
    }
}

