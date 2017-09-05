using MySystem.Models.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySystem.Controllers.Test
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Test()
        {
            Class1 model = new Class1();
            model.getData();
            model.GetWebContent("http://invoice.etax.nat.gov.tw/");
            return View(model);
        }
        [HttpPost]
        public ActionResult Test(Class1 model)
        {
            return View();
        }

    }
}
