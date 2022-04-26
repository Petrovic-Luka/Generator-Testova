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
    public partial class FrmKreirajOblast : Form
    {
        public int IdPredmeta;
        public FrmKreirajOblast(int id)
        {
            InitializeComponent();
            IdPredmeta = id;
        }

        private void FrmKreirajOblast_Load(object sender, EventArgs e)
        {

        }

        private void btnKreiraj_Click(object sender, EventArgs e)
        {
            Funkcije.DodajOblastUBazu(textBox1.Text, IdPredmeta);
            MessageBox.Show("Oblast uspesno kreirana", "sacuvano", MessageBoxButtons.OK);
            this.Close();
        }
    }
}
