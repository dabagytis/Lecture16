using Lecture16_1.Core.Contracts.IRepo;
using Lecture16_1.Core.Contracts.ISave;
using Lecture16_1.Core.Contracts.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Services
{
    public class SaveService : ISaveService
    {
        private readonly ICarService _carService;
        private readonly IClientService _clientService;
        private readonly IRentalService _rentalService;
        private readonly IWorkerService _workerService;

        private readonly ISaveClients _saveClients;
        private readonly ISaveElectricCars _saveElectricCars;
        private readonly ISavePetrolCars _savePetrolCars;
        private readonly ISaveRentals _saveRentals;
        private readonly ISaveWorkers _saveWorkers;
        public SaveService(ICarService carService, IClientService clientService, IRentalService rentalService, IWorkerService workerService, ISaveClients saveClients, ISaveElectricCars saveElectricCars, ISavePetrolCars savePetrolCars, ISaveRentals saveRentals, ISaveWorkers saveWorkers)
        {
            _carService = carService;
            _clientService = clientService;
            _rentalService = rentalService;
            _workerService = workerService;

            _saveClients = saveClients;
            _saveElectricCars = saveElectricCars;
            _savePetrolCars = savePetrolCars;
            _saveRentals = saveRentals;
            _saveWorkers = saveWorkers;
        }

        public async Task SaveAll()
        {
            _saveClients.ClientsToFile(await _clientService.GetAllClients());
            _saveElectricCars.ElectricCarsToFile(await _carService.GetAllCars());
            _savePetrolCars.PetrolCarsToFile(await _carService.GetAllCars());
            _saveRentals.RentalsToFile(await _rentalService.GetAllRentals());
            _saveWorkers.WorkersToFile(await _workerService.GetAllWorkers());
        }
    }
}
