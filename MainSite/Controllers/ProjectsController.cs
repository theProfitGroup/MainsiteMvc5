using MainSite.Core;
using System.Web.Mvc;

namespace MainSite.Controllers
{
    public class ProjectsController : BaseController
    {
        //
        // GET: /Works/

        public ActionResult Index()
        {
            return View("~/Views/Home/Projects.cshtml");
        }
    }
}
