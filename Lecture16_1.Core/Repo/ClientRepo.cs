using Dapper;
using Lecture16_1.Core.Contracts.IRepo;
using Lecture16_1.Core.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Repo
{
    public class ClientRepo : IClientRepo
    {
        private readonly string _connectionString;
        public ClientRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Methods

        public async Task AddClient(Klientas klientas)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                await connection.ExecuteAsync("INSERT INTO Klientai (Vardas, Pavarde, ElPastas, Telefonas) VALUES (@Vardas, @Pavarde, @ElPastas, @Telefonas)", klientas);
            }
        }

        public async Task DeleteClient(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                await connection.ExecuteAsync("DELETE FROM Klientai WHERE Id = @id", new { id });
            }
        }

        public async Task<List<Klientas>> GetAllClients()
        {
            List<Klientas> allClients = new List<Klientas>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                allClients = (await connection.QueryAsync<Klientas>("SELECT * FROM Klientai")).ToList();
            }
            return allClients;
        }

        public async Task<Klientas> GetClient(int id)
        {
            Klientas clientById = new Klientas();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                clientById = await connection.QueryFirstAsync<Klientas>("SELECT * FROM Klientai WHERE Id = @Id", new { Id = id });
            }
            return clientById;
        }

        public async Task UpdateClient(Klientas klientas)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                await connection.ExecuteAsync("UPDATE Klientai SET Vardas = @Vardas , Pavarde = @Pavarde , ElPastas = @ElPastas , Telefonas = @Telefonas WHERE Id = @Id", klientas);
            }
        }
    }
}
