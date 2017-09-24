using MySystem.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySystem.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult LogInPage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LogInPage(UserData model)
        {

            return View(model);
        }
        public ActionResult CreatAccountPage()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CreatAccountPage(UserData model)
        {

            return View(model);
        }
    }
}
