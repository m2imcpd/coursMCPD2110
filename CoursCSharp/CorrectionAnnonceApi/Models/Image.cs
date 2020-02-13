using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CorrectionAnnonceApi.Models
{
    public class Image
    {
        private int id;
        private string urlImage;
        private int annonceId;

        public int Id { get => id; set => id = value; }

        public string UrlImage { get => urlImage; set => urlImage = value; }

        public int AnnonceId { get => annonceId; set => annonceId = value; }

        [JsonIgnore]
        public Annonce Annonce { get; set; }
    }
}
