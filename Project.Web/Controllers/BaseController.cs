using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Controllers
{
    public class BaseController : Controller
    {
        protected string Culture => RouteData.Values["culture"].ToString()?.ToLower();

    }
}
