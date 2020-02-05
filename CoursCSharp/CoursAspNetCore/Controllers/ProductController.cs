using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CoursAspNetCore.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursAspNetCore.Controllers
{
    public class ProductController : Controller
    {
        private IHostingEnvironment _env;

        public ProductController(IHostingEnvironment env)
        {
            _env = env;
        }
        public IActionResult Index(string message)
        {
            ViewBag.message = message;
            List<Product> products = Product.GetProducts();
            products.ForEach(p =>
            {
                p.UrlImage = $"{Request.Scheme}://{Request.Host.Value}/{p.UrlImage}";
            });
            return View(products);
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

        public IActionResult AddProduct(string Title, string price, IFormFile image)
        {
            Product product = new Product();
            if(image != null)
            {
                string pathFile = _env.WebRootPath + @"\images\" + Title + "-" + image.FileName;
                FileStream stream = System.IO.File.Create(pathFile);
                image.CopyTo(stream);
                stream.Close();
                product.UrlImage = $"images/{Title}-{image.FileName}";
            }     
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