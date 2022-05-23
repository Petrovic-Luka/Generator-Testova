
namespace GeneratorTestova
{
    partial class FrmAzurirajPitanja
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
            this.components = new System.ComponentModel.Container();
            this.cmbPredmet = new System.Windows.Forms.ComboBox();
            this.cmbOblast = new System.Windows.Forms.ComboBox();
            this.btnDodajPitanja = new System.Windows.Forms.Button();
            this.btnIzvuci = new System.Windows.Forms.Button();
            this.btnObris = new System.Windows.Forms.Button();
            this.checkBoxCeo = new System.Windows.Forms.CheckBox();
            this.FileDialogOtvori = new System.Windows.Forms.OpenFileDialog();
            this.saveFileIzvuci = new System.Windows.Forms.SaveFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnObrisiPredmet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbPredmet
            // 
            this.cmbPredmet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPredmet.FormattingEnabled = true;
            this.cmbPredmet.Location = new System.Drawing.Point(21, 43);
            this.cmbPredmet.Name = "cmbPredmet";
            this.cmbPredmet.Size = new System.Drawing.Size(204, 41);
            this.cmbPredmet.TabIndex = 0;
            this.cmbPredmet.SelectedIndexChanged += new System.EventHandler(this.cmbPredmet_SelectedIndexChanged);
            // 
            // cmbOblast
            // 
            this.cmbOblast.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOblast.FormattingEnabled = true;
            this.cmbOblast.Location = new System.Drawing.Point(231, 43);
            this.cmbOblast.Name = "cmbOblast";
            this.cmbOblast.Size = new System.Drawing.Size(249, 41);
            this.cmbOblast.TabIndex = 1;
            // 
            // btnDodajPitanja
            // 
            this.btnDodajPitanja.Location = new System.Drawing.Point(21, 150);
            this.btnDodajPitanja.Name = "btnDodajPitanja";
            this.btnDodajPitanja.Size = new System.Drawing.Size(119, 75);
            this.btnDodajPitanja.TabIndex = 2;
            this.btnDodajPitanja.Text = "Dodaj pitanja";
            this.btnDodajPitanja.UseVisualStyleBackColor = true;
            this.btnDodajPitanja.Click += new System.EventHandler(this.btnDodajPitanja_Click);
            this.btnDodajPitanja.MouseHover += new System.EventHandler(this.btnDodajPitanja_MouseHover);
            // 
            // btnIzvuci
            // 
            this.btnIzvuci.Location = new System.Drawing.Point(146, 150);
            this.btnIzvuci.Name = "btnIzvuci";
            this.btnIzvuci.Size = new System.Drawing.Size(119, 75);
            this.btnIzvuci.TabIndex = 3;
            this.btnIzvuci.Text = "Izvuci pitanja";
            this.btnIzvuci.UseVisualStyleBackColor = true;
            this.btnIzvuci.Click += new System.EventHandler(this.btnIzvuci_Click);
            this.btnIzvuci.MouseHover += new System.EventHandler(this.btnIzvuci_MouseHover);
            // 
            // btnObris
            // 
            this.btnObris.Location = new System.Drawing.Point(271, 150);
            this.btnObris.Name = "btnObris";
            this.btnObris.Size = new System.Drawing.Size(119, 75);
            this.btnObris.TabIndex = 4;
            this.btnObris.Text = "Obrisi pitanja";
            this.btnObris.UseVisualStyleBackColor = true;
            this.btnObris.Click += new System.EventHandler(this.btnObris_Click);
            this.btnObris.MouseHover += new System.EventHandler(this.btnObris_MouseHover);
            // 
            // checkBoxCeo
            // 
            this.checkBoxCeo.AutoSize = true;
            this.checkBoxCeo.Location = new System.Drawing.Point(231, 90);
            this.checkBoxCeo.Name = "checkBoxCeo";
            this.checkBoxCeo.Size = new System.Drawing.Size(180, 37);
            this.checkBoxCeo.TabIndex = 5;
            this.checkBoxCeo.Text = "Ceo predmet";
            this.checkBoxCeo.UseVisualStyleBackColor = true;
            this.checkBoxCeo.CheckedChanged += new System.EventHandler(this.checkBoxCeo_CheckedChanged);
            // 
            // FileDialogOtvori
            // 
            this.FileDialogOtvori.FileName = "openFileDialog1";
            // 
            // saveFileIzvuci
            // 
            this.saveFileIzvuci.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            // 
            // btnObrisiPredmet
            // 
            this.btnObrisiPredmet.Location = new System.Drawing.Point(396, 150);
            this.btnObrisiPredmet.Name = "btnObrisiPredmet";
            this.btnObrisiPredmet.Size = new System.Drawing.Size(119, 75);
            this.btnObrisiPredmet.TabIndex = 6;
            this.btnObrisiPredmet.Text = "Obrisi predmet";
            this.btnObrisiPredmet.UseVisualStyleBackColor = true;
            this.btnObrisiPredmet.Click += new System.EventHandler(this.btnObrisiPredmet_Click);
            this.btnObrisiPredmet.MouseHover += new System.EventHandler(this.btnObrisiPredmet_MouseHover);
            // 
            // FrmAzurirajPitanja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(550, 479);
            this.Controls.Add(this.btnObrisiPredmet);
            this.Controls.Add(this.checkBoxCeo);
            this.Controls.Add(this.btnObris);
            this.Controls.Add(this.btnIzvuci);
            this.Controls.Add(this.btnDodajPitanja);
            this.Controls.Add(this.cmbOblast);
            this.Controls.Add(this.cmbPredmet);
            this.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "FrmAzurirajPitanja";
            this.Text = "Azuriraj pitanja";
            this.Load += new System.EventHandler(this.FrmAzurirajPitanja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbPredmet;
        private System.Windows.Forms.ComboBox cmbOblast;
        private System.Windows.Forms.Button btnDodajPitanja;
        private System.Windows.Forms.Button btnIzvuci;
        private System.Windows.Forms.Button btnObris;
        private System.Windows.Forms.CheckBox checkBoxCeo;
        private System.Windows.Forms.OpenFileDialog FileDialogOtvori;
        private System.Windows.Forms.SaveFileDialog saveFileIzvuci;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnObrisiPredmet;
    }
}