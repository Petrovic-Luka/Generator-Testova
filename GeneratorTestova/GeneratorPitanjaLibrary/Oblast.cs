using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorPitanjaLibrary
{
    public class Oblast
    {
        /// <summary>
        /// Id oblasti u bazi
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Naziv oblasti
        /// </summary>
        public string Naziv { get; set; }
        /// <summary>
        /// Id predmeta u bazi kome ova oblast pripada
        /// </summary>
        public int IdPredmeta { get; set; }
    }
}
