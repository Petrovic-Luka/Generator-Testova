using GeneratorPitanjaLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratorTestova
{
    public partial class FrmPredmeti : Form
    {
        public FrmPredmeti()
        {
            InitializeComponent();
        }

        private  void PopuniListuPredmeta()
        {
            List<Predmet> pomocna= Funkcije.GetPredmet_All();
            cmbPredmeti.DataSource = pomocna;
            cmbPredmeti.DisplayMember = "Naziv";
        }

        private void FrmPredmeti_Load(object sender, EventArgs e)
        {
            PopuniListuPredmeta();
        }

        private void btnIzaberi_Click(object sender, EventArgs e)
        {
            if (cmbPredmeti.SelectedItem != null)
            {
                Predmet p = (Predmet)cmbPredmeti.SelectedItem;
                FrmOblast frm = new FrmOblast(p.ID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Odaberite predmet", "Los input",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnDodajOblast_Click(object sender, EventArgs e)
        {
            if (cmbPredmeti.SelectedItem != null)
            {

            }
            else
            {
                MessageBox.Show("Odaberite predmet", "Los input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDodajPredmet_Click(object sender, EventArgs e)
        {
            FrmKreirajPredmet frm = new FrmKreirajPredmet();
            frm.ShowDialog();
            PopuniListuPredmeta();
        }

        private void btnPitanja_Click(object sender, EventArgs e)
        {
            FrmAzurirajPitanja frm = new FrmAzurirajPitanja();
            frm.ShowDialog();
            PopuniListuPredmeta();
        }
    }
}
