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
    public class RentalRepo : IRentalRepo
    {
        private readonly string _connectionString;
        public RentalRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Methods

        public void AddRental(NuomosUzsakymas nuomosUzsakymas)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("INSERT INTO NuomosUzsakymai (KlientasId, DarbuotojasId, AutomobilisId, PradziosData, PabaigosData, Kaina) VALUES (@KlientasId, @DarbuotojasId, @AutomobilisId, @PradziosData, @PabaigosData, @Kaina)", nuomosUzsakymas);
            }
        }

        public void DeleteRental(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("DELETE FROM NuomosUzsakymai WHERE Id = @id", new { id });
            }
        }

        public List<NuomosUzsakymas> GetAllRentals()
        {
            List<NuomosUzsakymas> allRentals = new List<NuomosUzsakymas>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                allRentals = connection.Query<NuomosUzsakymas>("SELECT * FROM NuomosUzsakymai").ToList();
            }
            return allRentals;
        }

        public NuomosUzsakymas GetRental(int id)
        {
            NuomosUzsakymas rentalById = new NuomosUzsakymas();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                rentalById = connection.QueryFirst<NuomosUzsakymas>("SELECT * FROM NuomosUzsakymai WHERE Id = @Id", new { Id = id });
            }
            return rentalById;
        }

        public List<NuomosUzsakymas> GetRentalsByCar(int id)
        {
            List<NuomosUzsakymas> rentalsByCar = new List<NuomosUzsakymas>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                rentalsByCar = connection.Query<NuomosUzsakymas>("SELECT * FROM NuomosUzsakymai WHERE AutomobilisId = @AutomobilisId", new { AutomobilisId = id }).ToList();
            }
            return rentalsByCar;
        }

        public List<NuomosUzsakymas> GetRentalsByClient(int id)
        {
            List<NuomosUzsakymas> rentalsByClient = new List<NuomosUzsakymas>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                rentalsByClient = connection.Query<NuomosUzsakymas>("SELECT * FROM NuomosUzsakymai WHERE KlientasId = @KlientasId", new { KlientasId = id }).ToList();
            }
            return rentalsByClient;
        }

        public List<NuomosUzsakymas> GetRentalsByWorker(int id)
        {
            List<NuomosUzsakymas> rentalsByWorker = new List<NuomosUzsakymas>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                rentalsByWorker = connection.Query<NuomosUzsakymas>("SELECT * FROM NuomosUzsakymai WHERE DarbuotojasId = @DarbuotojasId", new { DarbuotojasId = id }).ToList();
            }
            return rentalsByWorker;
        }

        public List<NuomosUzsakymas> GetRentalsInDateRange(DateTime startDate, DateTime endDate)
        {
            List<NuomosUzsakymas> rentalsInDateRange = new List<NuomosUzsakymas>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                rentalsInDateRange = connection.Query<NuomosUzsakymas>("SELECT * FROM NuomosUzsakymai WHERE (PradziosData BETWEEN @startDate AND @endDate) AND (PabaigosData BETWEEN @startDate AND @endDate)", new { startDate, endDate }).ToList();
            }
            return rentalsInDateRange;
        }

        public void UpdateRental(NuomosUzsakymas nuomosUzsakymas)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("UPDATE NuomosUzsakymai SET KlientasId = @KlientasId , DarbuotojasId = @DarbuotojasId , AutomobilisId = @AutomobilisId , PradziosData = @PradziosData , PabaigosData = @PabaigosData , Kaina = @Kaina WHERE Id = @Id", nuomosUzsakymas);
            }
        }
    }
}
