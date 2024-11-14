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

        public void AddClient(Klientas klientas)
        {
            _clientRepo.AddClient(klientas);
        }

        public void DeleteClient(int id)
        {
            _clientRepo.DeleteClient(id);
        }

        public List<Klientas> GetAllClients()
        {
            return _clientRepo.GetAllClients();
        }

        public Klientas GetClient(int id)
        {
            return _clientRepo.GetClient(id);
        }

        public void UpdateClient(Klientas klientas)
        {
            _clientRepo.UpdateClient(klientas);
        }
    }
}
