using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoursApiEntity.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursApiEntity.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            DataContext db = new DataContext();
            return Ok(db.Client.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //Utilisation du Linq pour request sur une collection
            DataContext db = new DataContext();
            //ecriture historique
            //Client c = (from client in db.Client where client.Id == id select client).First();
            //ecriture avec expression lambda
            Client c = db.Client.FirstOrDefault(x => x.Id == id);
            // <=> sans linq
            //Client cc = null;
            //foreach(Client ccc in db.Client)
            //{
            //    if(ccc.Id == id)
            //    {
            //        cc = ccc;
            //        break;
            //    }
            //}
            return Ok(c);
        }

        [HttpGet("search/{nom}")]
        public IActionResult Get(string nom)
        {
            DataContext db = new DataContext();
            List<Client> clients = db.Client.Where(c => c.Nom.Contains(nom)).ToList();
            return Ok(clients);
        }
    }
}