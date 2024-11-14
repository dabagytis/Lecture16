using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Models
{
    public class Darbuotojas
    {
        public int Id { get; set; }
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public string Pareigos { get; set; }

        public Darbuotojas()
        {

        }

        public Darbuotojas(int id, string vardas, string pavarde, string pareigos)
        {
            Id = id;
            Vardas = vardas;
            Pavarde = pavarde;
            Pareigos = pareigos;
        }
    }
}
