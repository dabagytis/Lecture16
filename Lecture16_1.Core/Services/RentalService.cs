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
    public class RentalService : IRentalService
    {
        private readonly IRentalRepo _rentalRepo;
        private readonly IReceiptRepo _receiptRepo;
        private readonly ICarRepo _carRepo;
        public RentalService(IRentalRepo rentalRepo, IReceiptRepo receiptRepo, ICarRepo carRepo)
        {
            _rentalRepo = rentalRepo;
            _receiptRepo = receiptRepo;
            _carRepo = carRepo;
        }

        // Methods

        public void AddRental(NuomosUzsakymas nuomosUzsakymas)
        {
            _rentalRepo.AddRental(nuomosUzsakymas);
        }

        public void DeleteRental(int id)
        {
            _rentalRepo.DeleteRental(id);
        }

        public List<NuomosUzsakymas> GetAllRentals()
        {
            return _rentalRepo.GetAllRentals();
        }

        public NuomosUzsakymas GetRental(int id)
        {
            return _rentalRepo.GetRental(id);
        }

        public List<NuomosUzsakymas> GetRentalsByCar(int id)
        {
            return _rentalRepo.GetRentalsByCar(id);
        }

        public List<NuomosUzsakymas> GetRentalsByClient(int id)
        {
            return _rentalRepo.GetRentalsByClient(id);
        }

        public List<NuomosUzsakymas> GetRentalsByWorker(int id)
        {
            return _rentalRepo.GetRentalsByWorker(id);
        }

        public List<NuomosUzsakymas> GetRentalsInDateRange(DateTime startDate, DateTime endDate)
        {
            return _rentalRepo.GetRentalsInDateRange(startDate, endDate);
        }

        public void UpdateRental(NuomosUzsakymas nuomosUzsakymas)
        {
            _rentalRepo.UpdateRental(nuomosUzsakymas);
        }

        public void RentalReceipt(int id)
        {
            NuomosUzsakymas rentalForPrint = _rentalRepo.GetRental(id);
            Automobilis carForPrint = _carRepo.GetCar(rentalForPrint.AutomobilisId);
            _receiptRepo.RentalReceipt(rentalForPrint, carForPrint);
        }
    }
}
