using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture16_1.Core.Models
{
    public class Klientas
    {
        public int Id { get; set; }
        public string Vardas { get; set; }
        public string Pavarde { get; set; }
        public string ElPastas { get; set; }
        public string Telefonas { get; set; }
        [BsonId]
        public ObjectId MongoId { get; set; }

        public Klientas()
        {

        }

        public Klientas(int id, string vardas, string pavarde, string elPastas, string telefonas)
        {
            Id = id;
            Vardas = vardas;
            Pavarde = pavarde;
            ElPastas = elPastas;
            Telefonas = telefonas;
        }
    }
}
