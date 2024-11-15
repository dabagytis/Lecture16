using Lecture16_1.Core.Models;
using Lecture16_1.Core.Models.Car;
using Lecture16_1.Core.Contracts.ISave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Utils.CreateBackup
{
    public class SaveClients : ISaveClients
    {
        private string _clientsFileLocation;
        public SaveClients(string clientsFileLocation)
        {
            _clientsFileLocation = clientsFileLocation;
        }
        public void ClientsToFile(List<Klientas> klientai)
        {
            using (StreamWriter sw = new StreamWriter(_clientsFileLocation))
            {
                foreach (Klientas a in klientai)
                {
                    sw.WriteLine($"{a.Id};{a.Vardas} {a.Pavarde};{a.ElPastas};{a.Telefonas}");
                }
                sw.Close();
            }
        }
    }
}
