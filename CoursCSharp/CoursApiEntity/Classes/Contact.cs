using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoursApiEntity.Classes
{
    
    public class Contact
    {
        private int id;
        private string nom;
        private string prenom;
        private string telephone;
        private List<Email> emails;

        public int Id { get => id; set => id = value; }
        public string Nom { get => nom; set => nom = value; }
        public string Prenom { get => prenom; set => prenom = value; }
        public string Telephone { get => telephone; set => telephone = value; }
        public List<Email> Emails { get => emails; set => emails = value; }

        public Contact()
        {
            Emails = new List<Email>();
        }
    }
}
