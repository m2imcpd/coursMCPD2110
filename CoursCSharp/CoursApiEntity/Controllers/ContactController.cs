using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoursApiEntity.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoursApiEntity.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            DataContext db = new DataContext();
            return Ok(db.Contact.Include(c => c.Emails).ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DataContext db = new DataContext();
            return Ok(db.Contact.Include(c => c.Emails).FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Contact contact)
        {
            DataContext db = new DataContext();
            db.Contact.Add(contact);
            db.SaveChanges();
            return Ok(new { message = "contact added" });
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Contact contact)
        {
            DataContext db = new DataContext();
            Contact c = db.Contact.Include(x => x.Emails).FirstOrDefault(x => x.Id == id);
            if(c != null)
            {
                c.Nom = contact.Nom;
                c.Prenom = contact.Prenom;
                c.Telephone = contact.Telephone;
                if(contact.Emails.Count > 0)
                {
                    c.Emails.Clear();
                    c.Emails = contact.Emails;
                }
                db.SaveChanges();
                return Ok(new { message = "update Ok" });
            }
            else
            {
                return NotFound();
            } 
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DataContext db = new DataContext();
            Contact c = db.Contact.Include(x => x.Emails).FirstOrDefault(x => x.Id == id);
            if (c != null)
            {
                db.Contact.Remove(c);
                db.SaveChanges();
                return Ok(new { message = "Delete ok" });
            }
            else
            {
                return NotFound();
            }
        }
    }
}