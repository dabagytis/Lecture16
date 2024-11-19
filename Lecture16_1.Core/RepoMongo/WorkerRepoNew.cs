using Lecture16_1.Core.Contracts.IRepo;
using Lecture16_1.Core.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.RepoMongo
{
    public class WorkerRepoNew : IWorkerRepo
    {
        private readonly IMongoCollection<Darbuotojas> _workerRepoNew;
        public WorkerRepoNew(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("workerDB");
            _workerRepoNew = database.GetCollection<Darbuotojas>("workers");
        }

        public async Task AddWorker(Darbuotojas darbuotojas)
        {
            await _workerRepoNew.InsertOneAsync(darbuotojas);
        }

        public async Task DeleteWorker(int id)
        {
            await _workerRepoNew.DeleteOneAsync(d => d.Id == id);
        }

        public async Task<List<Darbuotojas>> GetAllWorkers()
        {
            return await _workerRepoNew.Find(_ => true).ToListAsync();
        }

        public async Task<Darbuotojas> GetWorker(int id)
        {
            return await _workerRepoNew.Find<Darbuotojas>(w => w.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateWorker(Darbuotojas darbuotojas)
        {
            await _workerRepoNew.ReplaceOneAsync(r => r.Id == darbuotojas.Id, darbuotojas);
        }
    }
}
