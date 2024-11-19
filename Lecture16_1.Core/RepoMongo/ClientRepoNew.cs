using Lecture16_1.Core.Contracts.IRepo;
using Lecture16_1.Core.Models;
using Lecture16_1.Core.Models.Car;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.RepoMongo
{
    public class ClientRepoNew : IClientRepo
    {
        private readonly IMongoCollection<Klientas> _clientRepoNew;
        public ClientRepoNew(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("clientDB");
            _clientRepoNew = database.GetCollection<Klientas>("clients");
        }

        public async Task AddClient(Klientas klientas)
        {
            await _clientRepoNew.InsertOneAsync(klientas);
        }

        public async Task DeleteClient(int id)
        {
            await _clientRepoNew.DeleteOneAsync(d => d.Id == id);
        }

        public async Task<List<Klientas>> GetAllClients()
        {
            return await _clientRepoNew.Find(_ => true).ToListAsync();
        }

        public async Task<Klientas> GetClient(int id)
        {
            return await _clientRepoNew.Find<Klientas>(k => k.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateClient(Klientas klientas)
        {
            await _clientRepoNew.ReplaceOneAsync(k => k.Id == klientas.Id, klientas);
        }
    }
}
