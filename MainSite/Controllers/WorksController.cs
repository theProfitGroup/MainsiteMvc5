using MainSite.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MainSite.Controllers
{
    public class WorksController : BaseController
    {
        //
        // GET: /Works/

        public ActionResult Index()
        {
            return View();
        }

    }
}
