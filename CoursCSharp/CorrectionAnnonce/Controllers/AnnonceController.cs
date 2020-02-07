using CorrectionAnnonce.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            return View();
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
    }

   
}
