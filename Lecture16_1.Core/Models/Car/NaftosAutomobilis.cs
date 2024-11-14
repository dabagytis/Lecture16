using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Models.Car
{
    public class NaftosAutomobilis : Automobilis
    {
        public decimal VariklioTuris { get; set; }
        public string DegaluTipas { get; set; }
        public decimal CO2Ismetimas { get; set; }

        public NaftosAutomobilis()
        {

        }

        public NaftosAutomobilis(int id, string pavadinimas, int metai, decimal nuomosKaina, decimal variklioTuris, string degaluTipas, decimal co2Ismetimas) : base(id, pavadinimas, metai, nuomosKaina)
        {
            VariklioTuris = variklioTuris;
            DegaluTipas = degaluTipas;
            CO2Ismetimas = co2Ismetimas;
        }
    }
}
