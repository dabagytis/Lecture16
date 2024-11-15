using Lecture16_1.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Contracts.ISave
{
    public interface ISaveClients
    {
        void ClientsToFile(List<Klientas> klientai);
    }
}
