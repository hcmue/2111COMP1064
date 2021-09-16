using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult XuLyTinhToan(string PhepToan, double SoHangA, double SoHangB)
        {
            var ketQua = 0.0;
            switch (PhepToan)
            {
                case "+": ketQua = SoHangA + SoHangB; break;
                case "-": ketQua = SoHangA - SoHangB; break;
                case "*": ketQua = SoHangA * SoHangB; break;
                case "/": ketQua = SoHangA / SoHangB; break;
                case "^": ketQua = Math.Pow(SoHangA, SoHangB); break;
                case "%": ketQua = SoHangA % SoHangB; break;
            }

            //return Content($"{SoHangA} {PhepToan} {SoHangB} = {ketQua}");
            ViewBag.A = SoHangA;
            ViewBag.B = SoHangB;
            ViewBag.PhepToan = PhepToan;
            ViewBag.KQ = ketQua;
            return View("Index");
        }
    }
}