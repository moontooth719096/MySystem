﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySystem.Controllers
{
    public class MainPageController : Controller
    {
        //
        // GET: /MainPage/

        public ActionResult Index()
        {
            return View();
        }

    }
}
