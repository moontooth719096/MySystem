using MySystem.ViewModels.Function;
using System;
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
            return View(model);
        }
        [HttpPost]
        public ActionResult MainFunctionAddPage(MainFunctionViewModel model)
        {
            string message = String.Empty;
            message = model.addMainFunction(model.MainFunctionName);
            return RedirectToAction("MainFunctionPage");
        }

        public ActionResult MainFunctionPage()
        {
            ViewBag.Title = "功能清單";
            MainFunctionViewModel model = new MainFunctionViewModel();
            model.getMainFunction();
            string message = String.Empty;
            return View(model);
        }
        [HttpPost]
        public ActionResult MainFunctionPage(MainFunctionViewModel model)
        {
            string message = String.Empty;
            if (model.Active == "Add")
            {
                message = model.addMainFunction(model.MainFunctionName);
            }
            if (model.Active == "Edit")
            {
                message = model.editMainFunction(model.MainFunctionName);
            }
            if (model.Active == "Delete")
            {
                message = model.deleteMainFunction();
            }
            return View(model);
            //return RedirectToAction("MainFunctionPage");
        }
        public ActionResult SubFunctionAddPage()
        {
            SubFunctionViewModel model = new SubFunctionViewModel();
            string message = String.Empty;
            message = model.get_MainFunctionList(); //取得網業類型
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
