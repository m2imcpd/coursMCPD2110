using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursApiEntity.Classes
{
    public class Adresse
    {
        private int id;
        private string rue;
        private string ville;
        private int clientId;


        public int Id { get => id; set => id = value; }
        public string Rue { get => rue; set => rue = value; }
        public string Ville { get => ville; set => ville = value; }
        public int ClientId { get => clientId; set => clientId = value; }

        [JsonIgnore]
        public Client Client { get; set; }
    }
}
