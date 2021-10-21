using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public IActionResult DangKyThanhVien()
        {
            return View();
        }

        [HttpPost]
        public IActionResult XuLyDangKyThanhVien()
        {
            return View();
        }
    }
}
