using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Buoi01.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult XoSo()
        {
            var rd = new Random();
            var danhSach = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                danhSach.Add(rd.Next(1, 55));
            }

            return View();
        }
    }
}