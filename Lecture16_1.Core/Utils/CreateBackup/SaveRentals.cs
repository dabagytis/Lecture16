using Lecture16_1.Core.Models;
using Lecture16_1.Core.Contracts.ISave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Utils.CreateBackup
{
    public class SaveRentals : ISaveRentals
    {
        private string _rentalsFileLocation;
        public SaveRentals(string rentalsFileLocation)
        {
            _rentalsFileLocation = rentalsFileLocation;
        }
        public void RentalsToFile(List<NuomosUzsakymas> nuomosUzsakymai)
        {
            using (StreamWriter sw = new StreamWriter(_rentalsFileLocation))
            {
                foreach (NuomosUzsakymas a in nuomosUzsakymai)
                {
                    sw.WriteLine($"{a.Id};{a.KlientasId};{a.DarbuotojasId};{a.AutomobilisId};{a.PradziosData};{a.PabaigosData};{a.Kaina}");
                }
                sw.Close();
            }
        }
    }
}
