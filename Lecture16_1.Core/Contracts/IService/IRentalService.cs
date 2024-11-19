using Lecture16_1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Contracts.IService
{
    public interface IRentalService
    {
        Task AddRental(NuomosUzsakymas nuomosUzsakymas);
        Task<NuomosUzsakymas> GetRental(int id);
        Task<List<NuomosUzsakymas>> GetAllRentals();
        Task UpdateRental(NuomosUzsakymas nuomosUzsakymas);
        Task DeleteRental(int id);
        Task<List<NuomosUzsakymas>> GetRentalsByCar(int id);
        Task<List<NuomosUzsakymas>> GetRentalsByClient(int id);
        Task<List<NuomosUzsakymas>> GetRentalsByWorker(int id);
        Task<List<NuomosUzsakymas>> GetRentalsInDateRange(DateTime startDate, DateTime endDate);
        void RentalReceipt(int id);
    }
}
