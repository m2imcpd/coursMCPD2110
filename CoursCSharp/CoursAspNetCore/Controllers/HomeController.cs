using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CoursAspNetCore.Models;

namespace CoursAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult DireBonjour()
        {
            //return new ContentResult { Content = "<h1>Bonjour tout le monde</h1>", ContentType="text/html" };
            //return new JsonResult(new { Nom = "abadi", Prenom = "Ihab" });
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
