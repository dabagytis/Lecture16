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
        Task AddCar(Automobilis automobilis);
        Task<Automobilis> GetCar(int id);
        Task<List<Automobilis>> GetAllCars();
        Task UpdateElectricCar(Automobilis automobilis);
        Task UpdatePetrolCar(Automobilis automobilis);
        Task DeleteCar(int id);
    }
}
