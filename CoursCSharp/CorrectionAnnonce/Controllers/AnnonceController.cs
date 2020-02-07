using CorrectionAnnonce.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CorrectionAnnonce.Controllers
{
    public class AnnonceController : Controller
    {
        private IHostingEnvironment _env;

        public AnnonceController(IHostingEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index()
        {
            ViewBag.Categorie = Enum.GetValues(typeof(Categorie));
            return View();
        }

        [HttpPost]
        public IActionResult GetAnnonces([FromBody] dynamic request)
        {
            Thread.Sleep(1000);
            return Ok(Annonce.GetAnnonces(request));
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            Annonce annonce = Annonce.GetAnnonceById(id);
            annonce.Image = $"{Request.Scheme}://{Request.Host.Value}/{annonce.Image}";
            ViewBag.isFavoris = LookForFavoris(id);
            return View(annonce);
        }

        public IActionResult Favoris()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FormulaireAnnonce()
        {
            ViewBag.Categorie = Enum.GetValues(typeof(Categorie));
            return View();
        }

        [HttpPost]
        public IActionResult PostAnnonce(Annonce annonce, IFormFile imageAnnonce)
        {
            if(imageAnnonce != null)
            {
                //Chaine unique pour avoir un nom unique pour chaque image 
                string img = Guid.NewGuid().ToString() + "-" + imageAnnonce.FileName;
                //string pathToUpload = _env.WebRootPath + @"\images\" + random + "-" + imageAnnonce.FileName;
                string pathToUpload = Path.Combine(_env.WebRootPath, "images", img);
                FileStream stream = System.IO.File.Create(pathToUpload);
                imageAnnonce.CopyTo(stream);
                stream.Close();
                annonce.Image = "images/" + img;
            }
            else
            {
                annonce.Image = "images/default.png";
            }
            
            if(annonce.Save())
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.message = "Erreur serveur";
                ViewBag.Categorie = Enum.GetValues(typeof(Categorie));
                return View("FormulaireAnnonce");
            }
            
        }
        [HttpGet]
        public IActionResult AddToFavoris(int id)
        {
            string jsonFavoris = HttpContext.Session.GetString("favoris");
            List<Annonce> favoris = (jsonFavoris != null) ? JsonConvert.DeserializeObject<List<Annonce>>(jsonFavoris) : new List<Annonce>();
            
            if (!LookForFavoris(id))
            {
                favoris.Add(Annonce.GetAnnonceById(id));
                HttpContext.Session.SetString("favoris", JsonConvert.SerializeObject(favoris));
                return Ok(new { error = false, message = "Annonce ajoutée" });
            }
            else
            {
                return Ok(new { error = true, message = "Annonce déja en favoris" });
            }
           
        }

        [HttpGet]
        public IActionResult RemoveFromFavoris(int id)
        {
            string jsonFavoris = HttpContext.Session.GetString("favoris");
            List<Annonce> favoris = JsonConvert.DeserializeObject<List<Annonce>>(jsonFavoris);

            if (LookForFavoris(id))
            {
                favoris.RemoveAt(favoris.FindIndex(a=> a.Id == id));
                HttpContext.Session.SetString("favoris", JsonConvert.SerializeObject(favoris));
                return Ok(new { error = false, message = "Annonce retirée" });
            }
            else
            {
                return Ok(new { error = true, message = "Annonce déja retirée" });
            }

        }

        private bool LookForFavoris(int id)
        {
            string jsonFavoris = HttpContext.Session.GetString("favoris");
            List<Annonce> favoris = (jsonFavoris != null) ? JsonConvert.DeserializeObject<List<Annonce>>(jsonFavoris) : new List<Annonce>();
            bool found = false;
            favoris.ForEach(a =>
            {
                if (a.Id == id)
                {
                    found = true;
                }
            });
            return found;
        }
    }

   
}
