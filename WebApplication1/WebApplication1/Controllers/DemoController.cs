using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

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
            var chuoiNgauNhien = MyTools.PhatSinhNgauNhien();
            //Lưu số ngẫu nhiên trên Server dùng Session
            HttpContext.Session.SetString("MaBaoMat", chuoiNgauNhien);

            ViewBag.ChuoiNgauNhien = chuoiNgauNhien;
            return View();
        }

        public IActionResult KiemTraMaBaoMat(string MaBaoMat)
        {
            var checkMatch = HttpContext.Session.GetString("MaBaoMat") == MaBaoMat;
            return Content(checkMatch ? "true" : "false");
        }

        [HttpPost]
        public IActionResult XuLyDangKyThanhVien()
        {
            return View();
        }
    }
}
