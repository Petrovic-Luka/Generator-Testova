using GeneratorPitanjaLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratorTestova
{
    public partial class FrmOblast : Form
    {
        /// <summary>
        /// id odabranog predmeta sa prethodne forme
        /// </summary>
        public int IdPredmeta;
        /// <summary>
        /// lista dostupnih oblasti za prosledjeni predmet
        /// </summary>
        private List<Oblast> dostupni;
        /// <summary>
        /// lista odabranih oblasti za test
        /// </summary>
        private List<Oblast> odabrani;
        public FrmOblast(int Id)
        {
            InitializeComponent();
            IdPredmeta = Id;
            odabrani = new List<Oblast>();
            dostupni = Funkcije.GetOblast(IdPredmeta);
            PopuniListuOblasti();
            //TODO pogledaj admin podesavanja za ostale kompove ako bude pravio problem
        }

        private void PopuniListuOblasti()
        {
            //popuni dropdown listu dostpunih predmeta
            cmbOblasti.DataSource = null;
            cmbOblasti.DataSource = dostupni;
            cmbOblasti.DisplayMember = "Naziv";
            //popuni listBox odabranih predmeta
            listBoxOdabrani.DataSource = null;
            listBoxOdabrani.DataSource = odabrani;
            listBoxOdabrani.DisplayMember = "Naziv";
        }
        private void FrmOblast_Load(object sender, EventArgs e)
        {

        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            //dodaje odabranu oblast iz dropdown liste u listBox
            if (cmbOblasti.SelectedItem!=null)
            {
                odabrani.Add((Oblast)cmbOblasti.SelectedItem);
                dostupni.Remove((Oblast)cmbOblasti.SelectedItem);
                PopuniListuOblasti();
            }
        }

        private void btnUkloni_Click(object sender, EventArgs e)
        {
            //vraca odabranu oblast iz listBox-a u dropdown
            if (listBoxOdabrani.SelectedItem!=null)
            {
                dostupni.Add((Oblast)listBoxOdabrani.SelectedItem);
                odabrani.Remove((Oblast)listBoxOdabrani.SelectedItem);
                PopuniListuOblasti();
            }
        }

        private void checkBoxSveOblasti_CheckedChanged(object sender, EventArgs e)
        {
            listBoxOdabrani.Enabled = !listBoxOdabrani.Enabled;
            cmbOblasti.Enabled = !cmbOblasti.Enabled;
            btnOdaberi.Enabled = !btnOdaberi.Enabled;
            btnUkloni.Enabled = !btnUkloni.Enabled;
        }

        private void btnGenerisiTest_Click(object sender, EventArgs e)
        {
            //samo poziva formu sa pitanjima i prosedjuje vrednosti generisanje se vrsi na sledecoj formi
            if(!checkBoxSveOblasti.Checked&&odabrani.Count==0)
            {
                MessageBox.Show("Nepravilan odabir", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (checkBoxSveOblasti.Checked)
            {
                FrmPitanja frm = new FrmPitanja(IdPredmeta, new List<Oblast>());
                frm.ShowDialog();
            }
            else
            {
                List<Oblast> proba = odabrani;
                FrmPitanja frm = new FrmPitanja(IdPredmeta, proba);
                frm.ShowDialog();
            }
        }

        private void btnKreirajOblast_Click(object sender, EventArgs e)
        {
            FrmKreirajOblast frm = new FrmKreirajOblast(IdPredmeta);
            frm.ShowDialog();
            dostupni = Funkcije.GetOblast(IdPredmeta);
            odabrani = new List<Oblast>();
            PopuniListuOblasti();
        }

        private void checkBoxSveOblasti_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("", checkBoxSveOblasti);
        }

    }
}
