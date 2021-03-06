using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Web.Controllers.Admin
{
    //[TranslatedRoute("en", "store/car")]
    //[TranslatedRoute("fr", "magasin/voiture")]
    //[TranslatedRoute("es", "tienda/coche")]
    public class CarsController : BaseController
    {
        private const string Path = "Cars";
        private readonly string _title = Resources.Resource.Cars;
        private readonly ILogger<CarsController> _logger;
        private readonly TranslationRoute _translationRoute;

        public CarsController(ILogger<CarsController> logger,
                                TranslationRoute translationRoute)
        {
            _logger = logger;
            _translationRoute = translationRoute;
        }


        [TranslatedRoute("en", "list")]
        [TranslatedRoute("fr", "liste")]
        [TranslatedRoute("fr", "lista")]
        public IActionResult List()
        {
            ViewData["Title"] = Path;

            var editActionTranslated = _translationRoute.ResolveLinks(Culture, "edit");
            var deleteActionTranslated = _translationRoute.ResolveLinks(Culture, "delete");
            var controllerTranslated = _translationRoute.ResolveLinks(Culture, "Cars");

            ViewBag.EditTranslated = $"{Culture}/{controllerTranslated}/{editActionTranslated}";
            ViewBag.DeleteTranslated = $"{Culture}/{controllerTranslated}/{deleteActionTranslated}";

            var view = $"~/views/store/{Path}/List.cshtml";

            return View(view);
        }


        [TranslatedRoute("en", "create")]
        [TranslatedRoute("fr", "créer")]
        public async Task<IActionResult> Create()
        {
            ViewData["Title"] = Path;
            ViewData["PageName"] = _title + " Create";


            var view = $"~/views/store/{Path}/Create.cshtml";

            return View(view);
        }



        //[HttpPost]
        //[TranslatedRoute("en", "create")]
        //[TranslatedRoute("fr", "créer")]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create([Bind("Title, TitleFr, ClientId")] CarModel Car)
        //{
        //    ViewData["Title"] = Path;

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var actionTranslated = _translationRoute.ResolveLinks(Culture, "ListCar");
        //            var controllerTranslated = _translationRoute.ResolveLinks(Culture, "Cars");

        //            return RedirectToAction(actionTranslated, controllerTranslated);
        //        }
        //        catch (Exception e)
        //        {
        //            return NotFound(e.Message);
        //        }
        //    }

        //    var view = $"~/views/store/{Path}/Create.cshtml";

        //    return View(view, Car);
        //}


        //[HttpGet]
        //[TranslatedRoute("en", "edit")]
        //[TranslatedRoute("fr", "modifier")]
        //public async Task<IActionResult> Edit(int id)
        //{
        //    ViewData["Title"] = Path;

        //    ViewData["PageName"] = _title + " Edit";


        //    if (id == 0)
        //    {
        //        return NotFound();
        //    }


        //    if (Car == null)
        //    {
        //        return NotFound();
        //    }

        //    var model = new CarViewModel
        //    {
        //        Id = Car.Id.ToString(),
        //        Title = Car.Title,
        //        TitleFr = Car.TitleFr,
        //        GarrenUser = garrenUser,
        //        ClientId = Convert.ToInt32(ViewData["ClientId"]),
        //        CurrentCulture = Culture
        //    };


        //    var view = $"~/views/store/{Path}/Edit.cshtml";

        //    return View(view, model);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[TranslatedRoute("en", "edit")]
        //[TranslatedRoute("fr", "modifier")]
        //public async Task<IActionResult> Edit(int id, [Bind("Id, Title")] CarModel Car)
        //{
        //    ViewData["Title"] = Path;

        //    if (id != Car.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            var actionTranslated = _translationRoute.ResolveLinks(Culture, "edit");
        //            var controllerTranslated = _translationRoute.ResolveLinks(Culture, "Cars");

        //            return RedirectToAction(actionTranslated, controllerTranslated, new { id = Car.Id });
        //        }
        //        catch (Exception e)
        //        {
        //            return NotFound(e.Message);
        //        }
        //    }
        //    var view = $"~/views/store/{Path}/Edit.cshtml";

        //    return View(view);
        //}


        //[HttpGet]
        //[TranslatedRoute("en", "delete")]
        //[TranslatedRoute("fr", "supprimer")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    ViewData["Title"] = Path;

        //    if (id == 0)
        //    {
        //        return NotFound();
        //    }

        //    if (Car == null)
        //    {
        //        return NotFound();
        //    }

        //    var model = new CarViewModel
        //    {
        //        Id = Car.Id.ToString(),
        //        Title = Car.Title,
        //        TitleFr = Car.TitleFr,
        //        GarrenUser = garrenUser,
        //        ClientId = Convert.ToInt32(ViewData["ClientId"]),
        //        CurrentCulture = Culture
        //    };

        //    var view = $"~/views/store/{Path}/Delete.cshtml";

        //    return View(view, model);
        //}


        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    ViewData["Title"] = Path;

        //    //var Car = await Business.Car.Get(GarrenUser.Id, Convert.ToInt32(id))
        //    var unused = await Business.Car.Delete(id, garrenUser.Id);
        //    try
        //    {
        //        var actionTranslated = _translationRoute.ResolveLinks(Culture, "listCar");
        //        var controllerTranslated = _translationRoute.ResolveLinks(Culture, "Cars");

        //        return RedirectToAction(actionTranslated, controllerTranslated);
        //    }
        //    catch (Exception ex)
        //    {

        //        ViewData["StatusMessage"] = "Error. Calm Down ^_^ and please contact your SysAdmin with this message: " + ex;
        //        var view = $"~/views/store/{Path}/Delete.cshtml";

        //        var Car = await Business.Car.Get(Convert.ToInt32(id), garrenUser.Id);

        //        return View(view, Car);
        //    }
        //}

    }
}
