
namespace GeneratorTestova
{
    partial class FrmOblast
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.cmbOblasti = new System.Windows.Forms.ComboBox();
            this.listBoxOdabrani = new System.Windows.Forms.ListBox();
            this.btnOdaberi = new System.Windows.Forms.Button();
            this.btnUkloni = new System.Windows.Forms.Button();
            this.checkBoxSveOblasti = new System.Windows.Forms.CheckBox();
            this.btnGenerisiTest = new System.Windows.Forms.Button();
            this.btnKreirajOblast = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Location = new System.Drawing.Point(12, 22);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(96, 33);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Oblasti";
            // 
            // cmbOblasti
            // 
            this.cmbOblasti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOblasti.FormattingEnabled = true;
            this.cmbOblasti.Location = new System.Drawing.Point(18, 138);
            this.cmbOblasti.Name = "cmbOblasti";
            this.cmbOblasti.Size = new System.Drawing.Size(215, 41);
            this.cmbOblasti.TabIndex = 1;
            // 
            // listBoxOdabrani
            // 
            this.listBoxOdabrani.FormattingEnabled = true;
            this.listBoxOdabrani.ItemHeight = 33;
            this.listBoxOdabrani.Location = new System.Drawing.Point(18, 183);
            this.listBoxOdabrani.Name = "listBoxOdabrani";
            this.listBoxOdabrani.Size = new System.Drawing.Size(342, 301);
            this.listBoxOdabrani.TabIndex = 2;
            // 
            // btnOdaberi
            // 
            this.btnOdaberi.Location = new System.Drawing.Point(239, 137);
            this.btnOdaberi.Name = "btnOdaberi";
            this.btnOdaberi.Size = new System.Drawing.Size(121, 40);
            this.btnOdaberi.TabIndex = 3;
            this.btnOdaberi.Text = "Odaberi";
            this.btnOdaberi.UseVisualStyleBackColor = true;
            this.btnOdaberi.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnUkloni
            // 
            this.btnUkloni.Location = new System.Drawing.Point(18, 492);
            this.btnUkloni.Name = "btnUkloni";
            this.btnUkloni.Size = new System.Drawing.Size(342, 39);
            this.btnUkloni.TabIndex = 4;
            this.btnUkloni.Text = "Ukloni odabranu";
            this.btnUkloni.UseVisualStyleBackColor = true;
            this.btnUkloni.Click += new System.EventHandler(this.btnUkloni_Click);
            // 
            // checkBoxSveOblasti
            // 
            this.checkBoxSveOblasti.AutoSize = true;
            this.checkBoxSveOblasti.Location = new System.Drawing.Point(18, 84);
            this.checkBoxSveOblasti.Name = "checkBoxSveOblasti";
            this.checkBoxSveOblasti.Size = new System.Drawing.Size(251, 37);
            this.checkBoxSveOblasti.TabIndex = 5;
            this.checkBoxSveOblasti.Text = "Odaberi sve oblasti";
            this.checkBoxSveOblasti.UseVisualStyleBackColor = true;
            this.checkBoxSveOblasti.CheckedChanged += new System.EventHandler(this.checkBoxSveOblasti_CheckedChanged);
            this.checkBoxSveOblasti.MouseHover += new System.EventHandler(this.checkBoxSveOblasti_MouseHover);
            // 
            // btnGenerisiTest
            // 
            this.btnGenerisiTest.Location = new System.Drawing.Point(18, 537);
            this.btnGenerisiTest.Name = "btnGenerisiTest";
            this.btnGenerisiTest.Size = new System.Drawing.Size(342, 40);
            this.btnGenerisiTest.TabIndex = 6;
            this.btnGenerisiTest.Text = "Generisi test";
            this.btnGenerisiTest.UseVisualStyleBackColor = true;
            this.btnGenerisiTest.Click += new System.EventHandler(this.btnGenerisiTest_Click);
            // 
            // btnKreirajOblast
            // 
            this.btnKreirajOblast.Location = new System.Drawing.Point(18, 583);
            this.btnKreirajOblast.Name = "btnKreirajOblast";
            this.btnKreirajOblast.Size = new System.Drawing.Size(342, 40);
            this.btnKreirajOblast.TabIndex = 7;
            this.btnKreirajOblast.Text = "Kreiraj oblast";
            this.btnKreirajOblast.UseVisualStyleBackColor = true;
            this.btnKreirajOblast.Click += new System.EventHandler(this.btnKreirajOblast_Click);
            // 
            // FrmOblast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(412, 689);
            this.Controls.Add(this.btnKreirajOblast);
            this.Controls.Add(this.btnGenerisiTest);
            this.Controls.Add(this.checkBoxSveOblasti);
            this.Controls.Add(this.btnUkloni);
            this.Controls.Add(this.btnOdaberi);
            this.Controls.Add(this.listBoxOdabrani);
            this.Controls.Add(this.cmbOblasti);
            this.Controls.Add(this.lblHeader);
            this.Font = new System.Drawing.Font("Times New Roman", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(8);
            this.Name = "FrmOblast";
            this.Text = "Oblast";
            this.Load += new System.EventHandler(this.FrmOblast_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.ComboBox cmbOblasti;
        private System.Windows.Forms.ListBox listBoxOdabrani;
        private System.Windows.Forms.Button btnOdaberi;
        private System.Windows.Forms.Button btnUkloni;
        private System.Windows.Forms.CheckBox checkBoxSveOblasti;
        private System.Windows.Forms.Button btnGenerisiTest;
        private System.Windows.Forms.Button btnKreirajOblast;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}