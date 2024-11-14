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

        public void AddCar(Automobilis automobilis)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                if(automobilis is ElektrinisAutomobilis)
                {
                    connection.Execute("INSERT INTO Automobiliai (Pavadinimas, Metai, NuomosKaina, BaterijosTalpa, MaxNuvaziuojamasAtstumas, IkrovimoLaikas) VALUES (@Pavadinimas, @Metai, @NuomosKaina, @BaterijosTalpa, @MaxNuvaziuojamasAtstumas, @IkrovimoLaikas)", automobilis);
                }
                else
                {
                    connection.Execute("INSERT INTO Automobiliai (Pavadinimas, Metai, NuomosKaina, VariklioTuris, DegaluTipas, CO2Ismetimas) VALUES (@Pavadinimas, @Metai, @NuomosKaina, @VariklioTuris, @DegaluTipas, @CO2Ismetimas)", automobilis);
                }
            }
        }

        public void DeleteCar(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("DELETE FROM Automobiliai WHERE Id = @id", new { id });
            }
        }

        public List<Automobilis> GetAllCars()
        {
            List<Automobilis> allCars = new List<Automobilis>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                allCars.AddRange(connection.Query<ElektrinisAutomobilis>("SELECT * FROM Automobiliai WHERE BaterijosTalpa != 0").ToList());

                allCars.AddRange(connection.Query<NaftosAutomobilis>("SELECT * FROM Automobiliai WHERE VariklioTuris != 0").ToList());
            }
            return allCars;
        }

        public Automobilis GetCar(int id)
        {
            Automobilis carById = new Automobilis();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                try
                {
                    carById = connection.QueryFirst<ElektrinisAutomobilis>("SELECT * FROM Automobiliai WHERE Id = @Id AND BaterijosTalpa != 0", new { Id = id });
                }
                catch
                {
                    carById = connection.QueryFirst<NaftosAutomobilis>("SELECT * FROM Automobiliai WHERE Id = @Id", new { Id = id });
                }
            }
            return carById;
        }

        public void UpdateElectricCar(Automobilis automobilis)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("UPDATE Automobiliai SET Pavadinimas = @Pavadinimas , Metai = @Metai , NuomosKaina = @NuomosKaina , BaterijosTalpa = @BaterijosTalpa , MaxNuvaziuojamasAtstumas = @MaxNuvaziuojamasAtstumas , IkrovimoLaikas = @IkrovimoLaikas WHERE Id = @Id", automobilis);
            }
        }

        public void UpdatePetrolCar(Automobilis automobilis)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();

                connection.Execute("UPDATE Automobiliai SET Pavadinimas = @Pavadinimas , Metai = @Metai , NuomosKaina = @NuomosKaina , VariklioTuris = @VariklioTuris , DegaluTipas = @DegaluTipas , CO2Ismetimas = @CO2Ismetimas WHERE Id = @Id", automobilis);
            }
        }
    }
}
