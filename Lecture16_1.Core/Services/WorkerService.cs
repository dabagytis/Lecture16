using Lecture16_1.Core.Contracts.IRepo;
using Lecture16_1.Core.Contracts.IService;
using Lecture16_1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Services
{
    public class WorkerService : IWorkerService
    {
        private readonly IWorkerRepo _workerRepo;
        public WorkerService(IWorkerRepo workerRepo)
        {
            _workerRepo = workerRepo;
        }

        // Methods

        public async Task AddWorker(Darbuotojas darbuotojas)
        {
            await _workerRepo.AddWorker(darbuotojas);
        }

        public async Task DeleteWorker(int id)
        {
            await _workerRepo.DeleteWorker(id);
        }

        public async Task<List<Darbuotojas>> GetAllWorkers()
        {
            return await _workerRepo.GetAllWorkers();
        }

        public async Task<Darbuotojas> GetWorker(int id)
        {
            return await _workerRepo.GetWorker(id);
        }

        public async Task UpdateWorker(Darbuotojas darbuotojas)
        {
            await _workerRepo.UpdateWorker(darbuotojas);
        }
    }
}
