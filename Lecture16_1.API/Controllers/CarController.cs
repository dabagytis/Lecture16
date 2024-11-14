using Lecture16_1.Core.Contracts.IService;
using Lecture16_1.Core.Models.Car;
using Lecture16_1.Core.Utils;
using Microsoft.AspNetCore.Mvc;
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
            _carService.AddCar(automobilis);
        }

        [HttpPost("AddPetrolCar")]
        public void AddPetrolCar(NaftosAutomobilis automobilis)
        {
            _carService.AddCar(automobilis);
        }

        [HttpDelete("DeleteCar")]
        public void DeleteCar(int id)
        {
            _carService.DeleteCar(id);
        }

        [HttpGet("GetAllCars")]
        public IActionResult GetAllCars()
        {
            return Ok(JsonCustomConverter.SerializeWithPolymorphism(_carService.GetAllCars()));
        }

        [HttpGet("GetAvailableCars")]
        public List<Automobilis> GetAvailableCars(DateTime startDate, DateTime endDate)
        {
            return _carService.GetAvailableCars(startDate, endDate);
        }

        [HttpGet("GetCar")]
        public Automobilis GetCar(int id)
        {
            return _carService.GetCar(id);
        }

        [HttpPatch("UpdateElectricCar")]
        public void UpdateElectricCar(ElektrinisAutomobilis automobilis)
        {
            _carService.UpdateCar(automobilis);
        }

        [HttpPatch("UpdatePetrolCar")]
        public void UpdatePetrolCar(NaftosAutomobilis automobilis)
        {
            _carService.UpdateCar(automobilis);
        }
    }
}
