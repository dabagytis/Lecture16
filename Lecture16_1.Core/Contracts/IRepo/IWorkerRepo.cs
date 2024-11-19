using Lecture16_1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Contracts.IRepo
{
    public interface IWorkerRepo
    {
        Task AddWorker(Darbuotojas darbuotojas);
        Task<Darbuotojas> GetWorker(int id);
        Task<List<Darbuotojas>> GetAllWorkers();
        Task UpdateWorker(Darbuotojas darbuotojas);
        Task DeleteWorker(int id);
    }
}
