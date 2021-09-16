using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Text.Json;

namespace Demo.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Student sv, string type)
        {
            if (type == "JSON")
            {
                var jsonString = JsonSerializer.Serialize(sv);
                var pathFile = Path.Combine(Directory.GetCurrentDirectory(), "Data", "sv.json");
                System.IO.File.WriteAllText(pathFile, jsonString);
            }
            else if(type == "TXT")
            {

            }
            return View();
        }

        public IActionResult DocFileJson()
        {
            var pathFile = Path.Combine(Directory.GetCurrentDirectory(), "Data", "sv.json");
            var jsonString = System.IO.File.ReadAllText(pathFile);
            var svModel = JsonSerializer.Deserialize<Student>(jsonString);

            return View("Index", svModel);
        }
    }
}