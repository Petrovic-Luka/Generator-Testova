using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorPitanjaLibrary
{
    public class Pitanje
    {
        /// <summary>
        /// Id pitanja u bazi
        /// </summary>
        public  int ID { get; set; }

        /// <summary>
        /// Tekst kako glasi dato pitanje
        /// </summary>
        public string Tekst { get; set; }
        /// <summary>
        /// Tacan odgovor na dato pitanje
        /// </summary>
        public string Odgovor { get; set; }
        /// <summary>
        /// Id oblasti u bazi kojoj ovo pitanje pripada
        /// </summary>
        public int IdOblasti { get; set; }
        /// <summary>
        /// Id predmeta 
        /// </summary>
        public int IdPredmeta { get; set; }
    }
}
