﻿using MainSite.Core;
using System.Web.Mvc;

namespace MainSite.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Blog()
        {
            return View();
        }

        public ActionResult Projects()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
