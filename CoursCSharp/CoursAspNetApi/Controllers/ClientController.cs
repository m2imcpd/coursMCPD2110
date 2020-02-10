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
    }
}