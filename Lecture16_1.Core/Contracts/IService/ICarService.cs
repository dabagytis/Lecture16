using Lecture16_1.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Contracts.IService
{
    public interface ICarService
    {
        void AddCar(Automobilis automobilis);
        Automobilis GetCar(int id);
        List<Automobilis> GetAllCars();
        void UpdateCar(Automobilis automobilis);
        void DeleteCar(int id);
        List<Automobilis> GetAvailableCars(DateTime startDate, DateTime endDate);
    }
}
