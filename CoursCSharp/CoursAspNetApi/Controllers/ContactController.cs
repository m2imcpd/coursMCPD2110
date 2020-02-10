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
    }
}