using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Models.Car
{
    public class ElektrinisAutomobilis : Automobilis
    {
        public decimal BaterijosTalpa { get; set; }
        public int MaxNuvaziuojamasAtstumas { get; set; }
        public decimal IkrovimoLaikas { get; set; }

        public ElektrinisAutomobilis()
        {

        }

        public ElektrinisAutomobilis(int id, string pavadinimas, int metai, decimal nuomosKaina, decimal baterijosTalpa, int maxNuvaziuojamasAtstumas, decimal ikrovimoLaikas) : base(id, pavadinimas, metai, nuomosKaina)
        {
            BaterijosTalpa = baterijosTalpa;
            MaxNuvaziuojamasAtstumas = maxNuvaziuojamasAtstumas;
            IkrovimoLaikas = ikrovimoLaikas;
        }
    }
}
