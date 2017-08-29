using MySystem.Models.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySystem.Controllers.Fumction
{
    public class FunctionController : Controller
    {
        //
        // GET: /Function/

        public ActionResult MainFunctionPage()
        {
            MainFunction model = new MainFunction();

            return View(model);
        }

    }
}
