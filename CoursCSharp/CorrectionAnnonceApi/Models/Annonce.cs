using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectionAnnonceApi.Models
{
    public class Annonce
    {
        private int id;
        private string titre;
        private string description;
        private int categorieId;
        private decimal prix;
        

        public int Id { get => id; set => id = value; }
        public string Titre { get => titre; set => titre = value; }
        public string Description { get => description; set => description = value; }
        public int CategorieId { get => categorieId; set => categorieId = value; }

        public List<Image> Images { get; set; }

        public Annonce()
        {
            Images = new List<Image>();
        }

        [JsonIgnore]
        public Categorie Categorie { get; set; }
        public decimal Prix { get => prix; set => prix = value; }
    }
}
