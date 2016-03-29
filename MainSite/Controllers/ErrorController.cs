using System;
using System.Web.Mvc;

namespace MainSite.Controllers
{
    public class ErrorController : Controller
    {
        //
        // GET: /Error/

        public ActionResult Index()
        {
            //return View();
            return RedirectToAction("NotFound");
        }

        public ActionResult NotFound(Exception error)
        {
            Response.StatusCode = 404;
            Response.Status = "404 HTTP";
            Response.StatusDescription = "Requested page does not exist";

            return View();
        }
    }
}
