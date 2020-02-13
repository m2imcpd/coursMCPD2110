using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CorrectionAnnonceApi.Models;
using CorrectionAnnonceApi.Tools;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CorrectionAnnonceApi.Controllers
{
    [EnableCors("allowsAll")]
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            DataContext db = new DataContext();
            return Ok(db.Categorie.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DataContext db = new DataContext();
            return Ok(db.Categorie.FirstOrDefault(c=> c.Id == id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]Categorie categorie)
        {
            DataContext db = new DataContext();
            db.Categorie.Add(categorie);
            db.SaveChanges();
            return Ok(new { categorieId = categorie.Id });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            DataContext db = new DataContext();
            Categorie categorieToDelete = db.Categorie.FirstOrDefault(c => c.Id == id);
            if(categorieToDelete != null)
            {
                db.Categorie.Remove(categorieToDelete);
                db.SaveChanges();
                return Ok(new { message = "deleted" });
            }
            else
            {
                return NotFound();
            }
        }
    }
}