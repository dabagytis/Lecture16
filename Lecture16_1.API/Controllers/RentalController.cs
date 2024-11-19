using Lecture16_1.Core.Contracts.IService;
using Lecture16_1.Core.Models;
using Lecture16_1.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
        public async Task AddRental(NuomosUzsakymas nuomosUzsakymas)
        {
            Log.Information("AddRental request received");
            try
            {
                await _rentalService.AddRental(nuomosUzsakymas);
                Log.Information("AddRental request completed");
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method AddRental. Exception thrown {e.Message}");
            }
        }

        [HttpDelete("DeleteRental")]
        public async Task DeleteRental(int id)
        {
            Log.Information("DeleteRental request received");
            try
            {
                await _rentalService.DeleteRental(id);
                Log.Information("DeleteRental request completed");
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method DeleteRental. Exception thrown {e.Message}");
            }
        }

        [HttpGet("GetAllRentals")]
        public async Task<IActionResult> GetAllRentals()
        {
            Log.Information("GetAllRentals request received");
            try
            {
                var x = await _rentalService.GetAllRentals();
                Log.Information("GetAllRentals request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method GetAllRentals. Exception thrown {e.Message}");
            }
            return NotFound();
        }

        [HttpGet("GetRental")]
        public async Task<IActionResult> GetRental(int id)
        {
            Log.Information("GetRental request received");
            try
            {
                var x = await _rentalService.GetRental(id);
                Log.Information("GetRental request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method GetRental. Exception thrown {e.Message}");
            }
            return NotFound();
        }

        [HttpGet("GetRentalsByCar")]
        public async Task<IActionResult> GetRentalsByCar(int id)
        {
            Log.Information("GetRentalsByCar request received");
            try
            {
                var x = await _rentalService.GetRentalsByCar(id);
                Log.Information("GetRentalsByCar request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method GetRentalsByCar. Exception thrown {e.Message}");
            }
            return NotFound();
        }

        [HttpGet("GetRentalsByClient")]
        public async Task<IActionResult> GetRentalsByClient(int id)
        {
            Log.Information("GetRentalsByClient request received");
            try
            {
                var x = await _rentalService.GetRentalsByClient(id);
                Log.Information("GetRentalsByClient request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method GetRentalsByClient. Exception thrown {e.Message}");
            }
            return NotFound();
        }

        [HttpGet("GetRentalsByWorker")]
        public async Task<IActionResult> GetRentalsByWorker(int id)
        {
            Log.Information("GetRentalsByWorker request received");
            try
            {
                var x = await _rentalService.GetRentalsByWorker(id);
                Log.Information("GetRentalsByWorker request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method GetRentalsByWorker. Exception thrown {e.Message}");
            }
            return NotFound();
        }

        [HttpGet("GetRentalsInDateRange")]
        public async Task<IActionResult> GetRentalsInDateRange(DateTime startDate, DateTime endDate)
        {
            Log.Information("GetRentalsInDateRange request received");
            try
            {
                var x = await _rentalService.GetRentalsInDateRange(startDate, endDate);
                Log.Information("GetRentalsInDateRange request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method GetRentalsInDateRange. Exception thrown {e.Message}");
            }
            return NotFound();
        }

        [HttpPatch("UpdateRental")]
        public async Task UpdateRental(NuomosUzsakymas nuomosUzsakymas)
        {
            Log.Information("UpdateRental request received");
            try
            {
                await _rentalService.UpdateRental(nuomosUzsakymas);
                Log.Information("UpdateRental request completed");
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method UpdateRental. Exception thrown {e.Message}");
            }
        }

        [HttpGet("RentalReceipt")]
        public void RentalReceipt(int id)
        {
            Log.Information("RentalReceipt request received");
            try
            {
                _rentalService.RentalReceipt(id);
                Log.Information("RentalReceipt request completed");
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method RentalReceipt. Exception thrown {e.Message}");
            }
        }
    }
}
