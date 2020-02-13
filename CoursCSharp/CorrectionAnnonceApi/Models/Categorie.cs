using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectionAnnonceApi.Models
{
    public class Categorie
    {
        private int id;
        private string titre;

        public int Id { get => id; set => id = value; }
        public string Titre { get => titre; set => titre = value; }

        public List<Annonce> Annonces { get; set; }

        public Categorie()
        {
            Annonces = new List<Annonce>();
        }
    }
}
