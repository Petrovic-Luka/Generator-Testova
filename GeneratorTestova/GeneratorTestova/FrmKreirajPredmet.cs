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
    public partial class FrmKreirajPredmet : Form
    {
        public FrmKreirajPredmet()
        {
            InitializeComponent();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Funkcije.DodajPredmetUBazu(txtNaziv.Text);
            MessageBox.Show("Predmet uspesno dodat");
            this.Close();
        }
    }
}
