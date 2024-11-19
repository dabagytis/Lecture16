using Dapper;
using Microsoft.Data.SqlClient;
using Lecture16_1.Core.Contracts.IRepo;
using Lecture16_1.Core.Models.Car;
using Lecture16_1.Core.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.ConstrainedExecution;
using Lecture16_1.Core.Models;

namespace Lecture16_1.Core.Repo
{
    public class CarRepo : ICarRepo
    {
        private readonly string _connectionString;
        public CarRepo(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Methods

        public async Task AddCar(Automobilis automobilis)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                if(automobilis is ElektrinisAutomobilis)
                {
                    await connection.ExecuteAsync("INSERT INTO Automobiliai (Pavadinimas, Metai, NuomosKaina, BaterijosTalpa, MaxNuvaziuojamasAtstumas, IkrovimoLaikas) VALUES (@Pavadinimas, @Metai, @NuomosKaina, @BaterijosTalpa, @MaxNuvaziuojamasAtstumas, @IkrovimoLaikas)", automobilis);
                }
                else
                {
                    await connection.ExecuteAsync("INSERT INTO Automobiliai (Pavadinimas, Metai, NuomosKaina, VariklioTuris, DegaluTipas, CO2Ismetimas) VALUES (@Pavadinimas, @Metai, @NuomosKaina, @VariklioTuris, @DegaluTipas, @CO2Ismetimas)", automobilis);
                }
            }
        }

        public async Task DeleteCar(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                await connection.ExecuteAsync("DELETE FROM Automobiliai WHERE Id = @id", new { id });
            }
        }

        public async Task<List<Automobilis>> GetAllCars()
        {
            List<Automobilis> allCars = new List<Automobilis>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                allCars.AddRange((await connection.QueryAsync<ElektrinisAutomobilis>("SELECT * FROM Automobiliai WHERE BaterijosTalpa != 0")).ToList());

                allCars.AddRange((await connection.QueryAsync<NaftosAutomobilis>("SELECT * FROM Automobiliai WHERE VariklioTuris != 0")).ToList());
            }
            return allCars;
        }

        public async Task<Automobilis> GetCar(int id)
        {
            Automobilis carById = new Automobilis();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                try
                {
                    carById = await connection.QueryFirstAsync<ElektrinisAutomobilis>("SELECT * FROM Automobiliai WHERE Id = @Id AND BaterijosTalpa != 0", new { Id = id });
                }
                catch
                {
                    carById = await connection.QueryFirstAsync<NaftosAutomobilis>("SELECT * FROM Automobiliai WHERE Id = @Id", new { Id = id });
                }
            }
            return carById;
        }

        public async Task UpdateElectricCar(Automobilis automobilis)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                await connection.ExecuteAsync("UPDATE Automobiliai SET Pavadinimas = @Pavadinimas , Metai = @Metai , NuomosKaina = @NuomosKaina , BaterijosTalpa = @BaterijosTalpa , MaxNuvaziuojamasAtstumas = @MaxNuvaziuojamasAtstumas , IkrovimoLaikas = @IkrovimoLaikas WHERE Id = @Id", automobilis);
            }
        }

        public async Task UpdatePetrolCar(Automobilis automobilis)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                await connection.ExecuteAsync("UPDATE Automobiliai SET Pavadinimas = @Pavadinimas , Metai = @Metai , NuomosKaina = @NuomosKaina , VariklioTuris = @VariklioTuris , DegaluTipas = @DegaluTipas , CO2Ismetimas = @CO2Ismetimas WHERE Id = @Id", automobilis);
            }
        }
    }
}
