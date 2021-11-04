using Microsoft.AspNetCore.Mvc;
using MyWebApp.Entities;
using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebApp.Controllers
{
    public class HangHoaController : Controller
    {
        private readonly eStore20Context _context;

        public HangHoaController(eStore20Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var dsHangHoa = _context.HangHoa.AsQueryable();

            var result = dsHangHoa.Select(hh => new HangHoaVM {
                DonGia = hh.DonGia.Value,
                Hinh = hh.Hinh,
                MaHh = hh.MaHh,
                MoTa = hh.MoTaDonVi,
                TenHh = hh.TenHh
            });

            return View(result);
        }

        public IActionResult Detail(int id)
        {
            var hangHoa = _context.HangHoa.SingleOrDefault(hh => hh.MaHh == id);
            return View(hangHoa);
        }
    }
}
