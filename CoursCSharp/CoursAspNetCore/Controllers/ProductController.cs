using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoursAspNetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoursAspNetCore.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(string message)
        {
            ViewBag.message = message;
            return View(Product.GetProducts());
        }
        public IActionResult FormProduct(string message, bool? type)
        {
            if (message != null)
            {
                ViewBag.message = message;
                ViewBag.type = type;
            }
            return View();
        }

        public IActionResult AddProduct(string Title, string price)
        {
            Product product = new Product();
            try
            {
                product.Title = Title;
                product.Price = price;
            }
            catch(Exception e)
            {
                return RedirectToAction("FormProduct", new { message = e.Message, type = true });
            }

            if (product.Save())
                return RedirectToAction("Index", new { message = "Produit ajouté" });
            else
                return RedirectToAction("FormProduct", new { message = "error serveur", type = true });
        }
    }
}