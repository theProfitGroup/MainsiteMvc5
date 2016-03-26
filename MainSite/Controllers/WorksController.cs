using MainSite.Core;
using System.Web.Mvc;

namespace MainSite.Controllers
{
    public class WorksController : BaseController
    {
        //
        // GET: /Works/

        public ActionResult Index()
        {
            return View("~/Views/Home/Works.cshtml");
        }
    }
}
