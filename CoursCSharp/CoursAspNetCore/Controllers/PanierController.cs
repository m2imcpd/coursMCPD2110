using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoursAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoursAspNetCore.Controllers
{
    public class PanierController : Controller
    {
        public IActionResult Index()
        {
            return View(Cart.GetAllCarts());
        }

        public IActionResult Detail(int id)
        {
            return View(Cart.GetCartById(id));
        }
    }
}