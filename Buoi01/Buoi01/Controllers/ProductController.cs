using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Buoi01.Models;

namespace Buoi01.Controllers
{
    public class ProductController : Controller
    {
        static List<Product> products = new List<Product>();
        public IActionResult Index()
        {
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            products.Add(product);
            return RedirectToAction("Index");
        }
    }
}