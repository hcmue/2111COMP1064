using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Areas.Admin.Controllers
{
    [Area("admin")]
    public class LoaiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
