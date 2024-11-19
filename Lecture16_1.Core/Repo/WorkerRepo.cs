using Dapper;
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
    public class WorkerRepo : IWorkerRepo
    {
        private readonly string _connectionString;
        public WorkerRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Methods

        public async Task AddWorker(Darbuotojas darbuotojas)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                await connection.ExecuteAsync("INSERT INTO Darbuotojai (Vardas, Pavarde, Pareigos) VALUES (@Vardas, @Pavarde, @Pareigos)", darbuotojas);
            }
        }

        public async Task DeleteWorker(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                await connection.ExecuteAsync("DELETE FROM Darbuotojai WHERE Id = @id", new { id });
            }
        }

        public async Task<List<Darbuotojas>> GetAllWorkers()
        {
            List<Darbuotojas> allWorkers = new List<Darbuotojas>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                allWorkers = (await connection.QueryAsync<Darbuotojas>("SELECT * FROM Darbuotojai")).ToList();
            }
            return allWorkers;
        }

        public async Task<Darbuotojas> GetWorker(int id)
        {
            Darbuotojas workerById = new Darbuotojas();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                workerById = await connection.QueryFirstAsync<Darbuotojas>("SELECT * FROM Darbuotojai WHERE Id = @Id", new { Id = id });
            }
            return workerById;
        }

        public async Task UpdateWorker(Darbuotojas darbuotojas)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                await connection.ExecuteAsync("UPDATE Darbuotojai SET Vardas = @Vardas , Pavarde = @Pavarde , Pareigos = @Pareigos WHERE Id = @Id", darbuotojas);
            }
        }
    }
}
