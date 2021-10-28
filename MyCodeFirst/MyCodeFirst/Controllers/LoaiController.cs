using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MyCodeFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCodeFirst.Controllers
{
    public class LoaiController : Controller
    {
        private MyDbContext _context;

        public LoaiController(MyDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Loais.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.MaLoaiTruoc = new SelectList(_context.Loais, "MaLoai", "TenLoai");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Loai model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
