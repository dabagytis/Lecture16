using Lecture16_1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Contracts.IRepo
{
    public interface IClientRepo
    {
        void AddClient(Klientas klientas);
        Klientas GetClient(int id);
        List<Klientas> GetAllClients();
        void UpdateClient(Klientas klientas);
        void DeleteClient(int id);
    }
}
