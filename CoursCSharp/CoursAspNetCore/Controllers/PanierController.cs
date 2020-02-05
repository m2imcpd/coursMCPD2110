using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoursAspNetCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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

        public IActionResult AddProduct(int id)
        {
            //Cart cart;
            string jsonCart = HttpContext.Session.GetString("panier");
            //if(jsonCart == null)
            //{
            //    cart = new Cart();

            //}
            //else
            //{
            //    cart = JsonConvert.DeserializeObject<Cart>(jsonCart);
            //}
            Cart cart = (jsonCart == null) ? new Cart() : JsonConvert.DeserializeObject<Cart>(jsonCart);
            cart.AddProductToCart(Product.GetProductById(id));
            HttpContext.Session.SetString("panier", JsonConvert.SerializeObject(cart));
            return RedirectToAction("Panier");
        }

        public IActionResult Panier()
        {
            string jsonCart = HttpContext.Session.GetString("panier");
            Cart cart = (jsonCart == null) ? new Cart() : JsonConvert.DeserializeObject<Cart>(jsonCart);
            cart.UpdateTotal();
            return View(cart);
        }
    }
}