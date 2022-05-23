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
    public partial class FrmPitanja : Form
    {
        /// <summary>
        /// Id predmeta za koji se uzimaju pitanja
        /// </summary>
        int idPredmeta;
        /// <summary>
        /// Lista oblasti za koju se uzimaju pitanja ako je test iz cele oblasti lista je null
        /// </summary>
        List<Oblast> oblasti;

        /// <summary>
        /// Lista pitanja koja ce biti na testu
        /// </summary>
        List<Pitanje> pitanja;

        /// <summary>
        /// Lista labela koje sadrze odgovore
        /// </summary>
        public List<Label> odgovori = new List<Label>();

        public FrmPitanja(int IdPredmet,List<Oblast> zadate)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            idPredmeta = IdPredmet;
            oblasti = zadate;
            pitanja = Funkcije.OdaberiPitanjaZaTest(idPredmeta, oblasti);           
            pitanja.Reverse();
            GenerisiKomponente();
            //TODO popravi formatiranje pitaja
            //dodaj numeraciju pitanja i tekst da je odgovor
        }

        /// <summary>
        /// generise Label komponente koje sadrze tekst pitanja i odgovore i postavlja odgovore na nevidljive
        /// </summary>
        private void GenerisiKomponente()
        {
            int brojac = 100;
            foreach (Pitanje p in pitanja)
            {
                Label tekst = new System.Windows.Forms.Label();
                if (p.Tekst.Length > 130)
                {
                    tekst.Text = NamestiString(p.Odgovor);
                }
                else tekst.Text = p.Tekst;
                tekst.Location = new Point(50, brojac);
                tekst.AutoSize = true;
                tekst.Font = new Font(FontFamily.GenericSerif, 24, FontStyle.Bold);
                 Label odgovor = new System.Windows.Forms.Label();
                if(p.Odgovor.Length> 130)
                {
                  odgovor.Text = NamestiString(p.Odgovor);
                }
                else odgovor.Text = p.Odgovor;
                odgovor.Location = new Point(65, brojac +50+ p.Tekst.Length/2);
                odgovor.AutoSize = true;
                odgovor.Visible = false;
                this.Controls.Add(odgovor);
                odgovori.Add(odgovor);
                this.Controls.Add(tekst);
                brojac = brojac + (int)(p.Odgovor.Length*0.4)+150;
                if (p.Odgovor.Length < 20) brojac += 50;
            }
        }
        /// <summary>
        /// Ubacuje znak za novi red nakon na poslednje pojavljivanje " " ili nakon 100 karaktera
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string NamestiString(string s)
        {
            s.LastIndexOf(' ');
            int prvi = 0;
            string pomocni = "";
            StringBuilder sb = new StringBuilder();
            for(int i=0;i< s.Length / 140; i++)
            {
                pomocni = s.Substring(prvi, 140);
                if (pomocni.Contains(" "))
                {
                    int spejs = pomocni.LastIndexOf(' ');
                    pomocni = pomocni.Insert(spejs, "\r\n");
                }
                else
                {
                    pomocni = pomocni.Insert(pomocni.Length, "\r\n-");
                }
                sb.Append(pomocni);
                prvi += 140;
            }
            pomocni = s.Substring(prvi, s.Length - prvi);
            sb.Append(pomocni);
            return sb.ToString();
        }
        private void FrmPitanja_Load(object sender, EventArgs e)
        {
        }

        public void btnPrikazi_Click(object sender, EventArgs e)
        {
            ///prikazuje ili skriva odgovore na sva pitanja
            foreach(Label l in odgovori)
            {
                l.Visible = !l.Visible;
            }
        }

        private void FrmPitanja_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void btnPrikazi_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Precica : space", btnPrikazi);
        }
    }
}
