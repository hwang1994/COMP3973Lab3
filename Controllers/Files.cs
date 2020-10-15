using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lab2.Models;
using System.IO;

using Microsoft.AspNetCore.Hosting;

namespace Lab2.Controllers
{
    public class FilesController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public FilesController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string[] files = Directory.GetFiles("wwwroot"); //apprently this works
            ViewBag.Files = files;
            return View();
        }

        public IActionResult Content(int id)
        {
            string[] files = Directory.GetFiles("TextFiles");
            string file = files[id];
            StreamReader streamReader = new StreamReader(file);
            ViewBag.lineData = streamReader.ReadLine();
            return View();
/*             string lineData = streamReader.ReadLine();
            return Content(id); */
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
