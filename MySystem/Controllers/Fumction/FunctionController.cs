using MySystem.ViewModels.Function;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MySystem.Controllers
{
    public class FunctionController : Controller
    {
        //
        // GET: /Function/

        public ActionResult MainFunctionAddPage()
        {
            MainFunctionViewModel model = new MainFunctionViewModel();
            string message = String.Empty;
            message = model.getWebType(); //取得網業類型
            return View(model);
        }
        [HttpPost]
        public ActionResult MainFunctionAddPage(MainFunctionViewModel model)
        {
            string message = String.Empty;
            message = model.addMainFunction(model.MainFunctionName, model.MainFunctionType);
            return RedirectToAction("MainFunctionAddPage");
        }
        public ActionResult SubFunctionAddPage()
        {
            SubFunctionViewModel model = new SubFunctionViewModel();
            string message = String.Empty;
            message = model.getWebType(); //取得網業類型
            return View(model);
        }
        [HttpPost]
        public ActionResult SubFunctionAddPage(SubFunctionViewModel model)
        {
            string message = String.Empty;
            model.addSubFunction();
            return RedirectToAction("SubFunctionAddPage");
        }
        public ActionResult FunctionTypeAddPage()
        {
            FunctionTypeViewModel model = new FunctionTypeViewModel();
            
            return View(model);
        }

    }
}
