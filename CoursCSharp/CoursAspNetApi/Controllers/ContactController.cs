using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoursAspNetApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursAspNetApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Contact> liste = Contact.GetContacts();
            liste.ForEach(c =>
            {
                c.Emails = Email.GetEmailContact(c.Id);
            });
            return Ok(liste);
        }

        [HttpGet("{phone}")]
        public IActionResult Get(string phone)
        {
            Contact c = Contact.GetContactByTelephone(phone);
            if(c != null)
            {
                c.Emails = Email.GetEmailContact(c.Id);
                return Ok(c);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Contact contact)
        {
            if(contact.Save())
            {
                foreach(Email m in contact.Emails)
                {
                    m.Save(contact.Id);
                }
                return Ok(new { contactId = contact.Id, message = "Added" });
            }
            else
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{phone}")]
        public IActionResult Put(string phone, [FromBody] Contact contact)
        {
            Contact oldContact = Contact.GetContactByTelephone(phone);
            if (oldContact != null)
            {
                oldContact.Emails = Email.GetEmailContact(oldContact.Id);
                oldContact.Nom = contact.Nom != null ? contact.Nom : oldContact.Nom;
                oldContact.Prenom = contact.Prenom != null ? contact.Prenom : oldContact.Prenom;
                oldContact.Telephone = contact.Telephone != null ? contact.Telephone : oldContact.Telephone;
                oldContact.Update();
                if(contact.Emails.Count > 0)
                {
                    foreach(Email e in oldContact.Emails)
                    {
                        e.Delete();
                    }
                    foreach(Email e in contact.Emails)
                    {
                        e.Save(oldContact.Id);
                    }
                }
                return Ok(new { message = "updated" });
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{phone}")]
        public IActionResult Delete(string phone)
        {
            Contact c = Contact.GetContactByTelephone(phone);
            if (c != null)
            {
                c.Emails = Email.GetEmailContact(c.Id);
                foreach(Email e in c.Emails)
                {
                    e.Delete();
                }
                c.Delete();
                return Ok(new { message = "Deleted" });
            }
            else
            {
                return NotFound();
            }
        }
    }
}