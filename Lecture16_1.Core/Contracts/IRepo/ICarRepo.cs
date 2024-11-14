using Lecture16_1.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Contracts.IRepo
{
    public interface ICarRepo
    {
        void AddCar(Automobilis automobilis);
        Automobilis GetCar(int id);
        List<Automobilis> GetAllCars();
        void UpdateElectricCar(Automobilis automobilis);
        void UpdatePetrolCar(Automobilis automobilis);
        void DeleteCar(int id);
    }
}
