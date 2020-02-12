using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CoursApiEntity.Classes
{
    public class Email
    {
        private int id;
        private string mail;
        private int contactId;

        public int Id { get => id; set => id = value; }
        public string Mail { get => mail; set => mail = value; }

        [Column("contact_id")]
        public int ContactId { get => contactId; set => contactId = value; }

        [JsonIgnore]
        public Contact Contact { get; set; }
    }
}
