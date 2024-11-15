using Lecture16_1.Core.Contracts.IService;
using Microsoft.AspNetCore.Mvc;

namespace Lecture16_1.API.Controllers
{
    [ApiController]
    [Route("SaveData")]
    public class SaveController : ControllerBase
    {
        private readonly ISaveService _saveService;
        public SaveController(ISaveService saveService)
        {
            _saveService = saveService;
        }

        [HttpGet("SaveAll")]
        public void SaveAll()
        {
            _saveService.SaveAll();
        }
    }
}
