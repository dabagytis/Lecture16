using Lecture16_1.Core.Models.Car;
using Lecture16_1.Core.Contracts.ISave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Utils.CreateBackup
{
    public class SaveElectricCars : ISaveElectricCars
    {
        private string _electricCarsFileLocation;
        public SaveElectricCars(string electricCarsFileLocation)
        {
            _electricCarsFileLocation = electricCarsFileLocation;
        }
        public void ElectricCarsToFile(List<Automobilis> automobiliai)
        {
            using (StreamWriter sw = new StreamWriter(_electricCarsFileLocation))
            {
                foreach (Automobilis a in automobiliai)
                {
                    if (a is ElektrinisAutomobilis)
                    {
                        ElektrinisAutomobilis b = (ElektrinisAutomobilis)a;
                        sw.WriteLine($"{b.Id};{b.Pavadinimas};{b.Metai};{b.NuomosKaina};{b.BaterijosTalpa};{b.MaxNuvaziuojamasAtstumas};{b.IkrovimoLaikas}");
                    }
                }
                sw.Close();
            }
        }
    }
}
