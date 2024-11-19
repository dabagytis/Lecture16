using Lecture16_1.Core.Contracts.IRepo;
using Lecture16_1.Core.Contracts.IService;
using Lecture16_1.Core.Models;
using Lecture16_1.Core.Models.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepo _carRepo;
        private readonly IRentalRepo _rentalRepo;
        public CarService(ICarRepo carRepo, IRentalRepo rentalRepo)
        {
            _carRepo = carRepo;
            _rentalRepo = rentalRepo;
        }

        // Methods

        public async Task AddCar(Automobilis automobilis)
        {
            await _carRepo.AddCar(automobilis);
        }

        public async Task DeleteCar(int id)
        {
            await _carRepo.DeleteCar(id);
        }

        public async Task<List<Automobilis>> GetAllCars()
        {
            return await _carRepo.GetAllCars();
        }

        public async Task<List<Automobilis>> GetAvailableCars(DateTime startDate, DateTime endDate)
        {
            List<Automobilis> allCars = await GetAllCars();
            List<Automobilis> availableCars;
            Automobilis[] carArray = new Automobilis[allCars.Count];
            allCars.CopyTo(carArray);
            availableCars = carArray.ToList();
            List<NuomosUzsakymas> relevantRentals = await _rentalRepo.GetRentalsInDateRange(startDate, endDate);
            foreach (NuomosUzsakymas a in relevantRentals)
            {
                foreach (Automobilis b in allCars)
                {
                    if (b.Id == a.AutomobilisId)
                    {
                        availableCars.Remove(b);
                    }
                }
            }
            return availableCars;
        }

        public async Task<Automobilis> GetCar(int id)
        {
            return await _carRepo.GetCar(id);
        }

        public async Task UpdateCar(Automobilis automobilis)
        {
            if(automobilis is ElektrinisAutomobilis)
            {
                await _carRepo.UpdateElectricCar(automobilis);
            }
            else
            {
                await _carRepo.UpdatePetrolCar(automobilis);
            }
        }
    }
}
