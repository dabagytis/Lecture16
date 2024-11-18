using Lecture16_1.Core.Models.Car;
using Lecture16_1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Contracts.IRepo
{
    public interface IReceiptRepo
    {
        void RentalReceipt(NuomosUzsakymas nuomosUzsakymas, Automobilis automobilis);
    }
}
