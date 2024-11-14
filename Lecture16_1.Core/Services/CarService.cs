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

        public void AddCar(Automobilis automobilis)
        {
            _carRepo.AddCar(automobilis);
        }

        public void DeleteCar(int id)
        {
            _carRepo.DeleteCar(id);
        }

        public List<Automobilis> GetAllCars()
        {
            return _carRepo.GetAllCars();
        }

        public List<Automobilis> GetAvailableCars(DateTime startDate, DateTime endDate)
        {
            List<Automobilis> allCars = GetAllCars();
            List<Automobilis> availableCars;
            Automobilis[] carArray = new Automobilis[allCars.Count];
            allCars.CopyTo(carArray);
            availableCars = carArray.ToList();
            List<NuomosUzsakymas> relevantRentals = _rentalRepo.GetRentalsInDateRange(startDate, endDate);
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

        public Automobilis GetCar(int id)
        {
            return _carRepo.GetCar(id);
        }

        public void UpdateCar(Automobilis automobilis)
        {
            if(automobilis is ElektrinisAutomobilis)
            {
                _carRepo.UpdateElectricCar(automobilis);
            }
            else
            {
                _carRepo.UpdatePetrolCar(automobilis);
            }
        }
    }
}
