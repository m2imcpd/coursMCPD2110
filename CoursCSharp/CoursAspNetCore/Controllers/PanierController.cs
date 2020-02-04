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

        public IActionResult FormProduct(string message, bool? type)
        {
            if(message != null)
            {
                ViewBag.message = message;
                ViewBag.type = type;
            }
            return View();
        }

        public IActionResult AddProduct(Product product)
        {
            if(product.Save())
                return RedirectToAction("FormProduct", new { message="Produit ajouté", type=false});
            else
                return RedirectToAction("FormProduct", new { message="error serveur", type=true});
        }
    }
}