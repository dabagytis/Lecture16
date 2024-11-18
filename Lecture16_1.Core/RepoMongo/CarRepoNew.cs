using Lecture16_1.Core.Contracts.IRepo;
using Lecture16_1.Core.Contracts.IRepoMongo;
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

        public void AddCar(Automobilis automobilis)
        {
            throw new NotImplementedException();
        }

        public void DeleteCar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Automobilis> GetAllCars()
        {
            throw new NotImplementedException();
        }

        public Automobilis GetCar(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateElectricCar(Automobilis automobilis)
        {
            throw new NotImplementedException();
        }

        public void UpdatePetrolCar(Automobilis automobilis)
        {
            throw new NotImplementedException();
        }
    }
}
