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

        public void AddWorker(Darbuotojas darbuotojas)
        {
            _workerRepo.AddWorker(darbuotojas);
        }

        public void DeleteWorker(int id)
        {
            _workerRepo.DeleteWorker(id);
        }

        public List<Darbuotojas> GetAllWorkers()
        {
            return _workerRepo.GetAllWorkers();
        }

        public Darbuotojas GetWorker(int id)
        {
            return _workerRepo.GetWorker(id);
        }

        public void UpdateWorker(Darbuotojas darbuotojas)
        {
            _workerRepo.UpdateWorker(darbuotojas);
        }
    }
}
