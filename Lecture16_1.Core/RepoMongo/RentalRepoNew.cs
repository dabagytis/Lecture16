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
    public class RentalRepoNew : IRentalRepo
    {
        private readonly IMongoCollection<NuomosUzsakymas> _rentalRepoNew;
        public RentalRepoNew(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("rentalDB");
            _rentalRepoNew = database.GetCollection<NuomosUzsakymas>("rentals");
        }

        public async Task AddRental(NuomosUzsakymas nuomosUzsakymas)
        {
            await _rentalRepoNew.InsertOneAsync(nuomosUzsakymas);
        }

        public async Task DeleteRental(int id)
        {
            await _rentalRepoNew.DeleteOneAsync(d => d.Id == id);
        }

        public async Task<List<NuomosUzsakymas>> GetAllRentals()
        {
            return await _rentalRepoNew.Find(_ => true).ToListAsync();
        }

        public async Task<NuomosUzsakymas> GetRental(int id)
        {
            return await _rentalRepoNew.Find<NuomosUzsakymas>(r => r.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<NuomosUzsakymas>> GetRentalsByCar(int id)
        {
            return await _rentalRepoNew.Find<NuomosUzsakymas>(r => r.AutomobilisId == id).ToListAsync();
        }

        public async Task<List<NuomosUzsakymas>> GetRentalsByClient(int id)
        {
            return await _rentalRepoNew.Find<NuomosUzsakymas>(r => r.KlientasId == id).ToListAsync();
        }

        public async Task<List<NuomosUzsakymas>> GetRentalsByWorker(int id)
        {
            return await _rentalRepoNew.Find<NuomosUzsakymas>(r => r.DarbuotojasId == id).ToListAsync();
        }

        public async Task<List<NuomosUzsakymas>> GetRentalsInDateRange(DateTime startDate, DateTime endDate)
        {
            return await _rentalRepoNew.Find<NuomosUzsakymas>(r => r.PradziosData <= endDate && r.PabaigosData >= startDate).ToListAsync();
        }

        public async Task UpdateRental(NuomosUzsakymas nuomosUzsakymas)
        {
            await _rentalRepoNew.ReplaceOneAsync(r => r.Id == nuomosUzsakymas.Id, nuomosUzsakymas);
        }
    }
}
