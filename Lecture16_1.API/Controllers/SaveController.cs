using Lecture16_1.Core.Contracts.IService;
using Lecture16_1.Core.Models;
using Lecture16_1.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

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
            Log.Information("SaveAll request received");
            try
            {
                _saveService.SaveAll();
                Log.Information("SaveAll request completed");
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method SaveAll. Exception thrown {e.Message}");
            }
        }
    }
}
