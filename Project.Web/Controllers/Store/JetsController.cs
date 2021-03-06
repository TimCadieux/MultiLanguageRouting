using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Controllers.Admin
{
    public class JetsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
