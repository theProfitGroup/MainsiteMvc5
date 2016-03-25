﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
            return RedirectToAction("404");
        }


        public ActionResult NotFound()
        {
            return View();
        }

    }
}
