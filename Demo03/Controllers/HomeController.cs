using Demo03.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Demo03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult DemoSync()
        {
            var sw = new Stopwatch();
            sw.Start();
            var demo = new Demo();
            demo.Test01();
            demo.Test02();
            demo.Test03();
            sw.Stop();

            return Content($"Chạy hết {sw.ElapsedMilliseconds}ms");
        }

        public async Task<IActionResult> DemoAsyncs()
        {
            var sw = new Stopwatch();
            sw.Start();
            var demo = new Demo();
            var x = demo.Test01Async();
            var y = demo.Test02Async();
            var z = demo.Test03Async();
            await x;
            await y;
            await y;
            //Task.WaitAll();
            sw.Stop();

            return Content($"Chạy hết {sw.ElapsedMilliseconds}ms");
        }

        public IActionResult Demo()
        {
            return View();
        }
    }
}
