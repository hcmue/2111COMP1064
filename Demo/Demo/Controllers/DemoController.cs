using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class DemoController : Controller
    {
        static List<HangHoa> dsHangHoa = new List<HangHoa>();
        public IActionResult Index()
        {
            //var rnd = new Random();
            //var dsHangHoa = new List<HangHoa>();
            //dsHangHoa.Add(new HangHoa
            //{
            //    MaHh = 1,
            //    TenHh = $"IPhone {rnd.Next(6, 13)}",
            //    DonGia = rnd.Next(1, 39) * 1000000,
            //    SoLuong = 3
            //});
            //dsHangHoa.Add(new HangHoa
            //{
            //    MaHh = 1,
            //    TenHh = $"IPhone {rnd.Next(6, 13)}",
            //    DonGia = rnd.Next(1, 39) * 1000000,
            //    SoLuong = 3
            //});
            return View(dsHangHoa);
        }

        [HttpGet]
        public IActionResult ThemMoi()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ThemMoi(HangHoaModel hangHoaModel)
        {
            //dsHangHoa.Add(model);
            return RedirectToAction("Index");
        }

        public IActionResult Detail()
        {
            var hangHoa = new HangHoa
            {
                MaHh = 1,
                TenHh = "IPhone 13",
                DonGia = 25999000,
                SoLuong = 3
            };

            return View("ChiTiet", hangHoa);
            //return View("~/Views/Demo/ChiTiet.cshtml", hangHoa);
        }

        public IActionResult DemoTempData()
        {
            TempData["AAA"] = "HAHAHA";
            ViewBag.AAA = "HAAHHA";
            ViewData["AAA"] = "HI HI HI";

            return RedirectToAction("ShowResult");
        }

        public IActionResult ShowResult()
        {
            return View();
        }
    }
}