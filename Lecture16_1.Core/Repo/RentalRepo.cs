﻿using Dapper;
using Lecture16_1.Core.Contracts.IRepo;
using Lecture16_1.Core.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Repo
{
    public class RentalRepo : IRentalRepo
    {
        private readonly string _connectionString;
        public RentalRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Methods

        public async Task AddRental(NuomosUzsakymas nuomosUzsakymas)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                await connection.ExecuteAsync("INSERT INTO NuomosUzsakymai (KlientasId, DarbuotojasId, AutomobilisId, PradziosData, PabaigosData, Kaina) VALUES (@KlientasId, @DarbuotojasId, @AutomobilisId, @PradziosData, @PabaigosData, @Kaina)", nuomosUzsakymas);
            }
        }

        public async Task DeleteRental(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                await connection.ExecuteAsync("DELETE FROM NuomosUzsakymai WHERE Id = @id", new { id });
            }
        }

        public async Task<List<NuomosUzsakymas>> GetAllRentals()
        {
            List<NuomosUzsakymas> allRentals = new List<NuomosUzsakymas>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                allRentals = (await connection.QueryAsync<NuomosUzsakymas>("SELECT * FROM NuomosUzsakymai")).ToList();
            }
            return allRentals;
        }

        public async Task<NuomosUzsakymas> GetRental(int id)
        {
            NuomosUzsakymas rentalById = new NuomosUzsakymas();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                rentalById = await connection.QueryFirstAsync<NuomosUzsakymas>("SELECT * FROM NuomosUzsakymai WHERE Id = @Id", new { Id = id });
            }
            return rentalById;
        }

        public async Task<List<NuomosUzsakymas>> GetRentalsByCar(int id)
        {
            List<NuomosUzsakymas> rentalsByCar = new List<NuomosUzsakymas>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                rentalsByCar = (await connection.QueryAsync<NuomosUzsakymas>("SELECT * FROM NuomosUzsakymai WHERE AutomobilisId = @AutomobilisId", new { AutomobilisId = id })).ToList();
            }
            return rentalsByCar;
        }

        public async Task<List<NuomosUzsakymas>> GetRentalsByClient(int id)
        {
            List<NuomosUzsakymas> rentalsByClient = new List<NuomosUzsakymas>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                rentalsByClient = (await connection.QueryAsync<NuomosUzsakymas>("SELECT * FROM NuomosUzsakymai WHERE KlientasId = @KlientasId", new { KlientasId = id })).ToList();
            }
            return rentalsByClient;
        }

        public async Task<List<NuomosUzsakymas>> GetRentalsByWorker(int id)
        {
            List<NuomosUzsakymas> rentalsByWorker = new List<NuomosUzsakymas>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                rentalsByWorker = (await connection.QueryAsync<NuomosUzsakymas>("SELECT * FROM NuomosUzsakymai WHERE DarbuotojasId = @DarbuotojasId", new { DarbuotojasId = id })).ToList();
            }
            return rentalsByWorker;
        }

        public async Task<List<NuomosUzsakymas>> GetRentalsInDateRange(DateTime startDate, DateTime endDate)
        {
            List<NuomosUzsakymas> rentalsInDateRange = new List<NuomosUzsakymas>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                rentalsInDateRange = (await connection.QueryAsync<NuomosUzsakymas>("SELECT * FROM NuomosUzsakymai WHERE (PradziosData BETWEEN @startDate AND @endDate) OR (PabaigosData BETWEEN @startDate AND @endDate)", new { startDate, endDate })).ToList();
            }
            return rentalsInDateRange;
        }

        public async Task UpdateRental(NuomosUzsakymas nuomosUzsakymas)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                await connection.ExecuteAsync("UPDATE NuomosUzsakymai SET KlientasId = @KlientasId , DarbuotojasId = @DarbuotojasId , AutomobilisId = @AutomobilisId , PradziosData = @PradziosData , PabaigosData = @PabaigosData , Kaina = @Kaina WHERE Id = @Id", nuomosUzsakymas);
            }
        }
    }
}
