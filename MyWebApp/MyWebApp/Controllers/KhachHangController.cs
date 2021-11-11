using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Entities;
using MyWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyWebApp.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly eStore20Context _ctx;

        public KhachHangController(eStore20Context ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult DangNhap(string ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DangNhap(LoginVM model, string ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            if (ModelState.IsValid)
            {
                var khachHang = _ctx.KhachHang.SingleOrDefault(kh => kh.MaKh == model.MaKh && kh.MatKhau == model.MatKhau);

                if (khachHang != null)
                {
                    //tạo thông tin đăng nhập
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email, khachHang.Email),
                        new Claim(ClaimTypes.Name, khachHang.HoTen),
                        new Claim("FullName", khachHang.HoTen),
                        new Claim(ClaimTypes.Role, "Administrator"),
                        new Claim(ClaimTypes.Role, "Account"),
                    };

                    var claimsIdentity = new ClaimsIdentity(
    claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var authProperties = new AuthenticationProperties
                    {
                    };

                    await HttpContext.SignInAsync(
    CookieAuthenticationDefaults.AuthenticationScheme,
    new ClaimsPrincipal(claimsIdentity),
    authProperties);

                    if (string.IsNullOrEmpty(ReturnUrl))
                    {
                        return Redirect("/");
                    }
                    else
                    {
                        return Redirect(ReturnUrl);
                    }
                }
            }
            return View();
        }

        [Authorize]
        public IActionResult Profile()
        {
            var data = HttpContext.User.Claims;

            return View();
        }

        [Authorize]
        public async Task<IActionResult> DangXuat()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [Authorize(Roles ="Quản trị")]
        public IActionResult PhanQuyen()
        {
            //User.IsInRole()
            return View();
        }

        [Authorize]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
