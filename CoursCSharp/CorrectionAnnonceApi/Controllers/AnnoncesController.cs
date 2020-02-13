using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CorrectionAnnonceApi.Models;
using CorrectionAnnonceApi.Tools;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CorrectionAnnonceApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AnnoncesController : ControllerBase
    {
        private IHostingEnvironment _env;

        public AnnoncesController(IHostingEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public IActionResult Get()
        {
            DataContext db = new DataContext();
            return Ok(db.Annonce.Include(a => a.Categorie).Include(a=>a.Images).ToList());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            DataContext db = new DataContext();
            return Ok(db.Annonce.Include(a=>a.Categorie).Include(a => a.Images).FirstOrDefault(a => a.Id == id));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Annonce annonce)
        {
            DataContext db = new DataContext();
            db.Annonce.Add(annonce);
            db.SaveChanges();
            return Ok(new { annonceId = annonce.Id });
        }

        [HttpPut("upload/{id}")]
        public IActionResult Put(int id, [FromForm] ImageType data)
        {
            DataContext db = new DataContext();
            string img = Guid.NewGuid().ToString() + "-" + data.Image.FileName;
            //string pathToUpload = _env.WebRootPath + @"\images\" + random + "-" + imageAnnonce.FileName;
            string pathToUpload = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"), "images", img);
            FileStream stream = System.IO.File.Create(pathToUpload);
            data.Image.CopyTo(stream);
            stream.Close();
            Image image = new Image();
            image.UrlImage = "images/" + img;
            image.AnnonceId = id;
            db.Image.Add(image);
            db.SaveChanges();
            return Ok(new { imageId = image.Id});
        }
    }

    public class ImageType
    {
        public IFormFile Image { get; set; }
    }
}