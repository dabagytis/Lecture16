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
        void AddWorker(Darbuotojas darbuotojas);
        Darbuotojas GetWorker(int id);
        List<Darbuotojas> GetAllWorkers();
        void UpdateWorker(Darbuotojas darbuotojas);
        void DeleteWorker(int id);
    }
}
