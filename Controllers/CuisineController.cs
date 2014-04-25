using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcRouting.Controllers
{
    public class CuisineController : Controller
    {
        //
        // GET: /Cuisine/

        [Authorize]
        public ActionResult Search(string name = "french")
        {
            var message = Server.HtmlEncode(name);
            //return RedirectToAction("Index", "Home", new { name = name });
            //return RedirectToRoute("Default", new { controller = "Home", action = "About" });
            //return File(Server.MapPath("~/Content/Site.css"), "text/css");

            //return Json(new {Message = message, name = "Mahbub"}, JsonRequestBehavior.AllowGet);
            return Content(message);
        }

        

    }
}
