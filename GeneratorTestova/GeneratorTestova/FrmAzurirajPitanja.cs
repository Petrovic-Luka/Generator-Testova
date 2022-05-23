using GeneratorPitanjaLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneratorTestova
{
    public partial class FrmAzurirajPitanja : Form
    {
        public FrmAzurirajPitanja()
        {
            InitializeComponent();
        }

        private void FrmAzurirajPitanja_Load(object sender, EventArgs e)
        {
            cmbPredmet.DataSource = Funkcije.GetPredmet_All();
            cmbPredmet.DisplayMember = "Naziv";
            Predmet p = (Predmet)cmbPredmet.SelectedItem;
            cmbOblast.DataSource = Funkcije.GetOblast(p.ID);
            cmbOblast.DisplayMember = "Naziv";
        }

        private void cmbPredmet_SelectedIndexChanged(object sender, EventArgs e)
        {
            Predmet p = (Predmet)cmbPredmet.SelectedItem;
            cmbOblast.DataSource = null;
            cmbOblast.DataSource = Funkcije.GetOblast(p.ID);
            cmbOblast.DisplayMember = "Naziv";
        }

        private void checkBoxCeo_CheckedChanged(object sender, EventArgs e)
        {
            cmbOblast.Enabled = !cmbOblast.Enabled;
        }

        private void btnDodajPitanja_Click(object sender, EventArgs e)
        {
            Predmet p = (Predmet)cmbPredmet.SelectedItem;
            if (p == null)
            {
                MessageBox.Show("Nije odabran ni jedan predmet", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (FileDialogOtvori.ShowDialog() == DialogResult.OK)
            {
                string s = FileDialogOtvori.FileName;
                int pomPredmet = p.ID;
                Oblast o = (Oblast)cmbOblast.SelectedItem;
                try
                {
                    if (!checkBoxCeo.Checked && o != null)
                    {
                        Funkcije.UbacivanjePitanjaUBazu(s, pomPredmet, o.ID);
                        MessageBox.Show("Uspesno dodato", "Dodato", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    else
                    {
                        DialogResult dialogResult = MessageBox.Show("Pitanja koja nemaju oblast ce biti dostupna samo ako odaberete sve oblasti\n Nastavi?", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.Yes)
                        {
                            Funkcije.UbacivanjePitanjaUBazu(s, pomPredmet);
                            MessageBox.Show("Uspesno dodato", "Dodato", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnIzvuci_Click(object sender, EventArgs e)
        {
            Predmet p = (Predmet)cmbPredmet.SelectedItem;
            if(p==null)
            {
                MessageBox.Show("Nije odabran ni jedan predmet", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //System.IO.File.WriteAllLines(saveFileDialog1.FileName, richTextBox1.Lines);
            if (saveFileIzvuci.ShowDialog() == DialogResult.OK)
            {
                string s = saveFileIzvuci.FileName;               
                int pomPredmet = p.ID;
                Oblast o = (Oblast)cmbOblast.SelectedItem;
                try
                {
                    if (!checkBoxCeo.Checked && o != null)
                        Funkcije.ExportujPitanja(s, pomPredmet, o.ID);
                    else
                    {
                            Funkcije.ExportujPitanja(s, pomPredmet);
                    }
                    MessageBox.Show("Uspesno izvucena", "Izvuceno", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnObris_Click(object sender, EventArgs e)
        {
            Predmet p = (Predmet)cmbPredmet.SelectedItem;
            if (p == null)
            {
                MessageBox.Show("Nije odabran ni jedan predmet", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Da li zelite da obrisete pitanja", "Upozorenje", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                int pomPredmet = p.ID;
                Oblast o = (Oblast)cmbOblast.SelectedItem;
                try
                {
                    if (!checkBoxCeo.Checked && o != null)
                        Funkcije.ObrisiPitanja(pomPredmet, o.ID);
                    else
                        Funkcije.ObrisiPitanja(pomPredmet);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnDodajPitanja_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Dodaje pitanja za odabranu oblast", btnDodajPitanja);
        }

        private void btnIzvuci_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Generise tekst fajl sa svim pitanjim iz odabrane oblasti/predmeta", btnIzvuci);
        }

        private void btnObris_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Trajno brise pitanja za odabranu oblast/predmet", btnObris);
        }

        private void btnObrisiPredmet_Click(object sender, EventArgs e)
        {
            Predmet p = (Predmet)cmbPredmet.SelectedItem;
            if (p == null)
            {
               MessageBox.Show("Nije odabran ni jedan predmet", "Greska", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult dialogResult = MessageBox.Show("Da li zelite da obrisete Predmet", "Upozorenje", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    Funkcije.ObrisiPredmet(p.ID);
                    cmbPredmet.DataSource = Funkcije.GetPredmet_All();
                    cmbPredmet.DisplayMember = "Naziv";
                    Predmet pom = (Predmet)cmbPredmet.SelectedItem;
                    cmbOblast.DataSource = Funkcije.GetOblast(pom.ID);
                    cmbOblast.DisplayMember = "Naziv";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnObrisiPredmet_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Trajno brise predmet kao i sve oblasti i pitanja vezane za njega", btnObris);
        }
    }
}
