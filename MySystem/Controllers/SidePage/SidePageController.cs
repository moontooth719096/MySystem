using MySystem.Models.Function;
using MySystem.ViewModels.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySystem.Controllers
{
    public class SidePageController : Controller
    {
        //
        // GET: /SidePage/

        public ActionResult _SidePage()
        {
            SidePageViewModel model = new SidePageViewModel();
            model.getMainFunctionList();
            model.getSubFunctionList();
            return View(model);
        }

    }
}
