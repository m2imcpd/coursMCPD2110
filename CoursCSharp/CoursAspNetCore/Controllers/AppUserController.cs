using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoursAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoursAspNetCore.Controllers
{
    public class AppUserController : Controller
    {
        public IActionResult Index()
        {
            //return View("ListUsers");
            return RedirectToAction("ListUsers");
        }

        public IActionResult ListUsers()
        {
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

        public IActionResult PostFormulaire(AppUserModel user)
        {
            return View(user);
        }
    }
}