using MainSite.Core;
using System.Web.Mvc;

namespace MainSite.Controllers
{
    public class BlogController : BaseController
    {
        //
        // GET: /Blog/

        public ActionResult Index()
        {
            return View("~/Views/Home/Blog.cshtml");
        }

        public ActionResult Detail()
        {
            return View();
        }
    }
}
