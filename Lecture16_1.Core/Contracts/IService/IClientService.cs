using Lecture16_1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Contracts.IService
{
    public interface IClientService
    {
        Task AddClient(Klientas klientas);
        Task<Klientas> GetClient(int id);
        Task<List<Klientas>> GetAllClients();
        Task UpdateClient(Klientas klientas);
        Task DeleteClient(int id);
    }
}
