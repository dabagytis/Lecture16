using Lecture16_1.Core.Contracts.IService;
using Lecture16_1.Core.Models;
using Lecture16_1.Core.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Lecture16_1.API.Controllers
{
    [ApiController]
    [Route("Darbuotojai")]
    public class WorkerController : Controller
    {
        private readonly IWorkerService _workerService;
        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        [HttpPost("AddWorker")]
        public void AddWorker(Darbuotojas darbuotojas)
        {
            Log.Information("AddWorker request received");
            try
            {
                _workerService.AddWorker(darbuotojas);
                Log.Information("AddWorker request completed");
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method AddWorker. Exception thrown {e.Message}");
            }
        }

        [HttpDelete("DeleteWorker")]
        public void DeleteWorker(int id)
        {
            Log.Information("DeleteWorker request received");
            try
            {
                _workerService.DeleteWorker(id);
                Log.Information("DeleteWorker request completed");
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method DeleteWorker. Exception thrown {e.Message}");
            }
        }

        [HttpGet("GetAllWorkers")]
        public IActionResult GetAllWorkers()
        {
            Log.Information("GetAllWorkers request received");
            try
            {
                var x = _workerService.GetAllWorkers();
                Log.Information("GetAllWorkers request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method GetAllWorkers. Exception thrown {e.Message}");
            }
            return NotFound();
        }

        [HttpGet("GetWorker")]
        public IActionResult GetWorker(int id)
        {
            Log.Information("GetWorker request received");
            try
            {
                var x = _workerService.GetWorker(id);
                Log.Information("GetWorker request completed");
                return Ok(x);
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method GetWorker. Exception thrown {e.Message}");
            }
            return NotFound();
        }

        [HttpPatch("UpdateWorker")]
        public void UpdateWorker(Darbuotojas darbuotojas)
        {
            Log.Information("UpdateWorker request received");
            try
            {
                _workerService.UpdateWorker(darbuotojas);
                Log.Information("UpdateWorker request completed");
            }
            catch (Exception e)
            {
                Log.Error($"Could not complete method UpdateWorker. Exception thrown {e.Message}");
            }
        }
    }
}
