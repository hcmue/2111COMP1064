using Demo03.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo03.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DangKy(DangKy model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("loi", "Còn lỗi");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Employee employee)
        {
            if (ModelState.IsValid)
            {
                //save
            }
            return View();
        }


        public IActionResult KiemTraTrungMaNhanVien(string EmployeeNo)
        {
            string[] empNos = new string[] { "7777", "2222", "1313" };
            if (empNos.Contains(EmployeeNo))
            {
                return Json(false);
            }
            return Json(true);
        }
    }
}
