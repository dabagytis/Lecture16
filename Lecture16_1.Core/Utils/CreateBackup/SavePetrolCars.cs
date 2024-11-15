using Lecture16_1.Core.Models.Car;
using Lecture16_1.Core.Contracts.ISave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Utils.CreateBackup
{
    public class SavePetrolCars : ISavePetrolCars
    {
        private string _petrolCarsFileLocation;
        public SavePetrolCars(string petrolCarsFileLocation)
        {
            _petrolCarsFileLocation = petrolCarsFileLocation;
        }
        public void PetrolCarsToFile(List<Automobilis> automobiliai)
        {
            using (StreamWriter sw = new StreamWriter(_petrolCarsFileLocation))
            {
                foreach (Automobilis a in automobiliai)
                {
                    if (a is NaftosAutomobilis)
                    {
                        NaftosAutomobilis b = (NaftosAutomobilis)a;
                        sw.WriteLine($"{b.Id};{b.Pavadinimas};{b.Metai};{b.NuomosKaina};{b.VariklioTuris};{b.DegaluTipas};{b.CO2Ismetimas}");
                    }
                }
                sw.Close();
            }
        }
    }
}
