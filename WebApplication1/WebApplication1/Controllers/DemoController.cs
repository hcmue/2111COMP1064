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

        public IActionResult DemoPartial()
        {
            return PartialView("~/Views/Shared/Category.cshtml");
        }
        
        public IActionResult DemoPartialData()
        {
            var dsLoai = new List<Loai>();
            dsLoai.Add(new Loai { MaLoai = 1, TenLoai = "Laptop" });
            dsLoai.Add(new Loai { MaLoai = 2, TenLoai = "Tablet" });
            dsLoai.Add(new Loai { MaLoai = 3, TenLoai = "Phone" });

            return PartialView("~/Views/Shared/_Loai.cshtml", dsLoai);
        }
    }
}
