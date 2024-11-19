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
        Task AddCar(Automobilis automobilis);
        Task<Automobilis> GetCar(int id);
        Task<List<Automobilis>> GetAllCars();
        Task UpdateCar(Automobilis automobilis);
        Task DeleteCar(int id);
        Task<List<Automobilis>> GetAvailableCars(DateTime startDate, DateTime endDate);
    }
}
