using Lecture16_1.Core.Models;
using Lecture16_1.Core.Contracts.ISave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Utils.CreateBackup
{
    public class SaveWorkers : ISaveWorkers
    {
        private string _workerFileLocation;
        public SaveWorkers(string workerFileLocation)
        {
            _workerFileLocation = workerFileLocation;
        }
        public void WorkersToFile(List<Darbuotojas> darbuotojai)
        {
            using (StreamWriter sw = new StreamWriter(_workerFileLocation))
            {
                foreach (Darbuotojas a in darbuotojai)
                {
                    sw.WriteLine($"{a.Id};{a.Vardas} {a.Pavarde};{a.Pareigos}");
                }
                sw.Close();
            }
        }
    }
}
