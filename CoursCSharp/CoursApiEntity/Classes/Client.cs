using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoursApiEntity.Classes
{
    public class Client
    {
        private int id;
        private string nom;
        private string prenom;
        private string telephone;
        private List<Adresse> adresses;
        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public List<Adresse> Adresses { get => adresses; set => adresses = value; }

        public Client()
        {
            Adresses = new List<Adresse>();
        }
    }
}
