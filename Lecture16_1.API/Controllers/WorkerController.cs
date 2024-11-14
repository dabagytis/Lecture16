using Lecture16_1.Core.Contracts.IService;
using Lecture16_1.Core.Models;
using Microsoft.AspNetCore.Mvc;

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
            _workerService.AddWorker(darbuotojas);
        }

        [HttpDelete("DeleteWorker")]
        public void DeleteWorker(int id)
        {
            _workerService.DeleteWorker(id);
        }

        [HttpGet("GetAllWorkers")]
        public List<Darbuotojas> GetAllWorkers()
        {
            return _workerService.GetAllWorkers();
        }

        [HttpGet("GetWorker")]
        public Darbuotojas GetWorker(int id)
        {
            return _workerService.GetWorker(id);
        }

        [HttpPatch("UpdateWorker")]
        public void UpdateWorker(Darbuotojas darbuotojas)
        {
            _workerService.UpdateWorker(darbuotojas);
        }
    }
}
