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
    [TranslatedRoute("fr", "inicio")]
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            ViewData["Title"] = Resources.Resource.Home;

            return View();
        }

        [TranslatedRoute("en", "fighter-aircraft")]
        [TranslatedRoute("fr", "avion-de-chasse")]
        [TranslatedRoute("es", "avion-de-combate")]
        public IActionResult Jets()
        {
            ViewData["Title"] = Resources.Resource.Cars;

            var view = $"~/views/home/{nameof(Jets)}.cshtml";

            return View(view);
        }

        [TranslatedRoute("en", "cars")]
        [TranslatedRoute("fr", "automobiles")]
        [TranslatedRoute("es", "coches")]
        public IActionResult Cars()
        {
            ViewData["Title"] = Resources.Resource.Jets;

            var view = $"~/views/home/{nameof(Cars)}.cshtml";

            return View(view);
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
