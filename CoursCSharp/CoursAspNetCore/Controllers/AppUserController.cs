using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CoursAspNetCore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursAspNetCore.Controllers
{
    public class AppUserController : Controller
    {
        //service hosting Environement

        private IHostingEnvironment _env = null;
        private ISession _session;
        //private IHttpContextAccessor _context;

        public AppUserController(IHostingEnvironment env)
        {
            _env = env;
            
        }
        public IActionResult Index()
        {
            //return View("ListUsers");
            return RedirectToAction("ListUsers");
        }

        public IActionResult ListUsers()
        {
            ViewBag.contenuCookie = Request.Cookies["nomCookie"];
            ViewBag.contenuSession = HttpContext.Session.GetString("nomSession");
            List<AppUserModel> liste = AppUserModel.GetAllUsers();
            //Passage en utilisant le ViewData
            //ViewData["listeUsers"] = liste;
            //ViewBag.listeUsers = liste;
            return View(liste);
        }

        public IActionResult Detail(int id)
        {
            return View(id);
        }

        public IActionResult DetailMore(string nom, string prenom)
        {
            return View(new AppUserModel { Nom = nom, Prenom = prenom });
        }

        public IActionResult Formulaire()
        {
            return View();
        }

        //public IActionResult PostFormulaire(string nom, string prenom)
        //{
        //    AppUserModel u = new AppUserModel { Nom = nom, Prenom = prenom };
        //    return View(u);
        //}

        public IActionResult PostFormulaire(AppUserModel user, IFormFile avatar)
        {
            string pathFile = _env.WebRootPath + @"\images\"+avatar.FileName;
            FileStream stream = System.IO.File.Create(pathFile);
            avatar.CopyTo(stream);
            stream.Close();
            string pathBase = $"images/{avatar.FileName}";
            ViewBag.chemin = $"{Request.Scheme}://{Request.Host.Value}/{pathBase}";
            return View(user);
        }

        public IActionResult SaveCookie()
        {
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddHours(-1)
            };
            Response.Cookies.Append("nomCookie", "Value of cookie", options);
            return Content("Cookie crée");
        }


        public IActionResult SaveDataSession()
        {
            //ajouter une valeur dans une session
            HttpContext.Session.SetString("nomSession", "value session");
            //supprimer une session
            HttpContext.Session.Remove("nomSession");
            return Content("Session ajouté");
        }
        
    }
}