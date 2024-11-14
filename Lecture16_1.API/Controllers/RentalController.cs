using Lecture16_1.Core.Contracts.IService;
using Lecture16_1.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lecture16_1.API.Controllers
{
    [ApiController]
    [Route("NuomosUzsakymai")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalService _rentalService;
        public RentalController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpPost("AddRental")]
        public void AddRental(NuomosUzsakymas nuomosUzsakymas)
        {
            _rentalService.AddRental(nuomosUzsakymas);
        }

        [HttpDelete("DeleteRental")]
        public void DeleteRental(int id)
        {
            _rentalService.DeleteRental(id);
        }

        [HttpGet("GetAllRentals")]
        public List<NuomosUzsakymas> GetAllRentals()
        {
            return _rentalService.GetAllRentals();
        }

        [HttpGet("GetRental")]
        public NuomosUzsakymas GetRental(int id)
        {
            return _rentalService.GetRental(id);
        }

        [HttpGet("GetRentalsByCar")]
        public List<NuomosUzsakymas> GetRentalsByCar(int id)
        {
            return _rentalService.GetRentalsByCar(id);
        }

        [HttpGet("GetRentalsByClient")]
        public List<NuomosUzsakymas> GetRentalsByClient(int id)
        {
            return _rentalService.GetRentalsByClient(id);
        }

        [HttpGet("GetRentalsByWorker")]
        public List<NuomosUzsakymas> GetRentalsByWorker(int id)
        {
            return _rentalService.GetRentalsByWorker(id);
        }

        [HttpGet("GetRentalsInDateRange")]
        public List<NuomosUzsakymas> GetRentalsInDateRange(DateTime startDate, DateTime endDate)
        {
            return _rentalService.GetRentalsInDateRange(startDate, endDate);
        }

        [HttpPatch("UpdateRental")]
        public void UpdateRental(NuomosUzsakymas nuomosUzsakymas)
        {
            _rentalService.UpdateRental(nuomosUzsakymas);
        }
    }
}
