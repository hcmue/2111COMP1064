using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;
using System.Linq;
using System.Collections.Generic;
using MyWebApp.Helpers;
using MyWebApp.Entities;

namespace MyWebApp.Controllers
{
    public class GioHangController : Controller
    {
        const string SESSION_CART = "GioHang";

        public GioHangController(eStore20Context context)
        {
            _context = context;
        }

        public List<CartItem> Carts
        {
            get
            {
                var carts = HttpContext.Session.Get<List<CartItem>>(SESSION_CART);
                if(carts == null)
                {
                    carts = new List<CartItem>();
                }
                return carts;
            }
        }

        public eStore20Context _context { get; }

        public IActionResult Index()
        {
            return View(Carts);
        }

        public IActionResult AddToCart(int id, int SoLuong = 1)
        {
            //giỏ hàng hiện tại
            var carts = Carts;

            //kiếm xem có hàng hóa với id này chưa
            var cartItem = carts.SingleOrDefault(it => it.MaHh == id);

            if(cartItem == null)//chưa có
            {
                var hangHoa = _context.HangHoa.SingleOrDefault(hh => hh.MaHh == id);
                cartItem = new CartItem
                {
                    MaHh = id,
                    TenHh = hangHoa.TenHh,
                    SoLuong = SoLuong,
                    DonGia = hangHoa.DonGia.Value,
                    Hinh = hangHoa.Hinh
                };
                carts.Add(cartItem);
            }
            else
            {
                cartItem.SoLuong += SoLuong;
            }

            //cập nhật giỏ hàng (lưu session)
            HttpContext.Session.Set(SESSION_CART, carts);

            return RedirectToAction("Index");
        }
    }
}
