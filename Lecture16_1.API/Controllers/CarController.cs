using Lecture16_1.Core.Contracts.IService;
using Lecture16_1.Core.Models.Car;
using Lecture16_1.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Text.Json;

namespace Lecture16_1.API.Controllers
{
    [ApiController]
    [Route("Automobiliai")]
    public class CarController : ControllerBase
    {
        private readonly ICarService _carService;
        public CarController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpPost("AddElectricCar")]
        public void AddElectricCar(ElektrinisAutomobilis automobilis)
        {
            Log.Information("AddElectricCar request received");
            try
            {
                _carService.AddCar(automobilis);
                Log.Information("AddElectricCar request completed");
            }
            catch(Exception e)
            {
                Log.Error($"Could not complete method AddElectricCar. Exception thrown {e.Message}");
            }
        }

        [HttpPost("AddPetrolCar")]
        public void AddPetrolCar(NaftosAutomobilis automobilis)
        {
            Log.Information("AddPetrolCar request received");
            try
            {
                _carService.AddCar(automobilis);
                Log.Information("AddPetrolCar request completed");
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method AddPetrolCar. Exception thrown {e.Message}");
            }
        }

        [HttpDelete("DeleteCar")]
        public void DeleteCar(int id)
        {
            Log.Information("DeleteCar request received");
            try
            {
                _carService.DeleteCar(id);
                Log.Information("DeleteCar request completed");
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method DeleteCar. Exception thrown {e.Message}");
            }
        }

        [HttpGet("GetAllCars")]
        public IActionResult GetAllCars()
        {
            Log.Information("GetAllCars request received");
            try
            {
                var x = JsonCustomConverter.SerializeWithPolymorphism(_carService.GetAllCars());
                Log.Information("GetAllCars request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method GetAllCars. Exception thrown {e.Message}");
            }
            return NotFound();
        }

        [HttpGet("GetAvailableCars")]
        public IActionResult GetAvailableCars(DateTime startDate, DateTime endDate)
        {
            Log.Information("GetAvailableCars request received");
            try
            {
                var x = _carService.GetAvailableCars(startDate, endDate);
                Log.Information("GetAvailableCars request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method GetAvailableCars. Exception thrown {e.Message}");
            }
            return NotFound();
        }

        [HttpGet("GetCar")]
        public IActionResult GetCar(int id)
        {
            Log.Information("GetCar request received");
            try
            {
                var x = _carService.GetCar(id);
                Log.Information("GetCar request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method GetCar. Exception thrown {e.Message}");
            }
            return NotFound();
        }

        [HttpPatch("UpdateElectricCar")]
        public void UpdateElectricCar(ElektrinisAutomobilis automobilis)
        {
            Log.Information("UpdateElectricCar request received");
            try
            {
                _carService.UpdateCar(automobilis);
                Log.Information("UpdateElectricCar request completed");
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method UpdateElectricCar. Exception thrown {e.Message}");
            }
        }

        [HttpPatch("UpdatePetrolCar")]
        public void UpdatePetrolCar(NaftosAutomobilis automobilis)
        {
            Log.Information("UpdatePetrolCar request received");
            try
            {
                _carService.UpdateCar(automobilis);
                Log.Information("UpdatePetrolCar request completed");
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method UpdatePetrolCar. Exception thrown {e.Message}");
            }
        }
    }
}
