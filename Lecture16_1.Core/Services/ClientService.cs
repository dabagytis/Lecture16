using Lecture16_1.Core.Contracts.IRepo;
using Lecture16_1.Core.Contracts.IService;
using Lecture16_1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepo _clientRepo;
        public ClientService(IClientRepo clientRepo)
        {
            _clientRepo = clientRepo;
        }

        // Methods

        public async Task AddClient(Klientas klientas)
        {
            await _clientRepo.AddClient(klientas);
        }

        public async Task DeleteClient(int id)
        {
            await _clientRepo.DeleteClient(id);
        }

        public async Task<List<Klientas>> GetAllClients()
        {
            return await _clientRepo.GetAllClients();
        }

        public async Task<Klientas> GetClient(int id)
        {
            return await _clientRepo.GetClient(id);
        }

        public async Task UpdateClient(Klientas klientas)
        {
            await _clientRepo.UpdateClient(klientas);
        }
    }
}
