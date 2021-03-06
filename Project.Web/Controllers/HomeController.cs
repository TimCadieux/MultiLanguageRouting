using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Web.Helpers;
using Project.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Controllers
{

    [TranslatedRoute("en", "home")]
    [TranslatedRoute("fr", "accueil")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [TranslatedRoute("en", "Index")]
        [TranslatedRoute("fr", "Index")]
        public IActionResult Index()
        {
            return View();
        }

        [TranslatedRoute("en", "fighter-aircraft")]
        [TranslatedRoute("fr", "avion-de-chasse")]
        public IActionResult Jets()
        {
            return View();
        }

        [TranslatedRoute("en", "cars")]
        [TranslatedRoute("fr", "automobiles")]
        public IActionResult Cars()
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
    }
}
