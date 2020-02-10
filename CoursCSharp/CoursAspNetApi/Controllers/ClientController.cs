using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoursAspNetApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursAspNetApi.Controllers
{
    [EnableCors("allowsAll")]
    [Route("[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Client.GetClients());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(Client.GetClientById(id));
        }

        [HttpGet("Search/{nom}")]
        public IActionResult Get(string nom)
        {
            return Ok(Client.GetClientByName(nom));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Client client)
        {
            if (client.Save())
                return Ok(new { Id = client.Id });
            else
                return StatusCode(500);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id,[FromBody] Client client)
        {
            Client oldClient = Client.GetClientById(id);
            if(oldClient == null)
            {
                return NotFound();
            }
            else
            {
                oldClient.Nom = client.Nom != null ? client.Nom : oldClient.Nom;
                oldClient.Prenom = client.Prenom != null ? client.Prenom : oldClient.Prenom;
                oldClient.Telephone = client.Telephone != null ? client.Telephone : oldClient.Telephone;
                if(oldClient.Update())
                {
                    return Ok(new { message = "Update Ok" });
                }
                else
                {
                    return StatusCode(500);
                }
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if(Client.DeleteClientById(id))
            {
                return Ok(new { message = "Deleted" });
            }
            else
            {
                return NotFound();
            }
        }
    }
}