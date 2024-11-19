using Lecture16_1.Core.Contracts.IRepo;
using Lecture16_1.Core.Models.Car;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.RepoMongo
{
    public class CarRepoNew : ICarRepo
    {
        private readonly IMongoCollection<Automobilis> _carRepoNew;
        public CarRepoNew(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("carDB");
            _carRepoNew = database.GetCollection<Automobilis>("cars");
        }

        public async Task AddCar(Automobilis automobilis)
        {
            await _carRepoNew.InsertOneAsync(automobilis);
        }

        public async Task DeleteCar(int id)
        {
            await _carRepoNew.DeleteOneAsync(d => d.Id == id);
        }

        public async Task<List<Automobilis>> GetAllCars()
        {
            return await _carRepoNew.Find(_ => true).ToListAsync();
        }

        public async Task<Automobilis> GetCar(int id)
        {
            return await _carRepoNew.Find<Automobilis>(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateElectricCar(Automobilis automobilis)
        {
            await _carRepoNew.ReplaceOneAsync(c => c.Id == automobilis.Id, automobilis);
        }

        public async Task UpdatePetrolCar(Automobilis automobilis)
        {
            await _carRepoNew.ReplaceOneAsync(c => c.Id == automobilis.Id, automobilis);
        }
    }
}
