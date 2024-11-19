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

        public async Task AddRental(NuomosUzsakymas nuomosUzsakymas)
        {
            await _rentalRepo.AddRental(nuomosUzsakymas);
        }

        public async Task DeleteRental(int id)
        {
            await _rentalRepo.DeleteRental(id);
        }

        public async Task<List<NuomosUzsakymas>> GetAllRentals()
        {
            return await _rentalRepo.GetAllRentals();
        }

        public async Task<NuomosUzsakymas> GetRental(int id)
        {
            return await _rentalRepo.GetRental(id);
        }

        public async Task<List<NuomosUzsakymas>> GetRentalsByCar(int id)
        {
            return await _rentalRepo.GetRentalsByCar(id);
        }

        public async Task<List<NuomosUzsakymas>> GetRentalsByClient(int id)
        {
            return await _rentalRepo.GetRentalsByClient(id);
        }

        public async Task<List<NuomosUzsakymas>> GetRentalsByWorker(int id)
        {
            return await _rentalRepo.GetRentalsByWorker(id);
        }

        public async Task<List<NuomosUzsakymas>> GetRentalsInDateRange(DateTime startDate, DateTime endDate)
        {
            return await _rentalRepo.GetRentalsInDateRange(startDate, endDate);
        }

        public async Task UpdateRental(NuomosUzsakymas nuomosUzsakymas)
        {
            await _rentalRepo.UpdateRental(nuomosUzsakymas);
        }

        public void RentalReceipt(int id)
        {
            NuomosUzsakymas rentalForPrint = _rentalRepo.GetRental(id).Result;
            Automobilis carForPrint = _carRepo.GetCar(rentalForPrint.AutomobilisId).Result;
            _receiptRepo.RentalReceipt(rentalForPrint, carForPrint);
        }
    }
}
