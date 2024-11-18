using Lecture16_1.Core.Contracts.IRepo;
using Lecture16_1.Core.Models;
using Lecture16_1.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Repo
{
    public class ReceiptRepo : IReceiptRepo
    {
        public void RentalReceipt(NuomosUzsakymas nuomosUzsakymas, Automobilis automobilis)
        {
            using (StreamWriter sw = new StreamWriter($"{nuomosUzsakymas.Id}.txt"))
            {
                if (automobilis is ElektrinisAutomobilis)
                {
                    sw.WriteLine($"{automobilis.Pavadinimas} | Elektrinis automobilis | Paros Kaina:{automobilis.NuomosKaina}eur | Bendra kaina: {nuomosUzsakymas.Kaina}eur | {nuomosUzsakymas.PradziosData}-{nuomosUzsakymas.PabaigosData}");
                }
                else
                {
                    sw.WriteLine($"{automobilis.Pavadinimas} | Naftos automobilis | Paros Kaina:{automobilis.NuomosKaina}eur | Bendra kaina: {nuomosUzsakymas.Kaina}eur | {nuomosUzsakymas.PradziosData}-{nuomosUzsakymas.PabaigosData}");
                }
                sw.Close();
            }
        }
    }
}
