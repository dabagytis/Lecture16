using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Models.Car
{
    public class Automobilis
    {
        public int Id { get; set; }
        public string Pavadinimas { get; set; }
        public int Metai { get; set; }
        public decimal NuomosKaina { get; set; }

        public Automobilis()
        {

        }

        public Automobilis(int id, string pavadinimas, int metai, decimal nuomosKaina)
        {
            Id = id;
            Pavadinimas = pavadinimas;
            Metai = metai;
            NuomosKaina = nuomosKaina;
        }
    }
}
