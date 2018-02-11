using MySystem.ViewModels.Management;
using System;
using System.Web.Mvc;

namespace MySystem.Controllers
{
    public class ManagementController : Controller
    {
        public ActionResult CalendarPage()
        {
            ViewBag.Title = "行事表";
            CalendarViewModel model = new CalendarViewModel();
            model.init();
            model.getCalendar();
            string message = String.Empty;
            return View(model);
        }
        
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CalendarPage(CalendarViewModel model)
        {
            string message = String.Empty;
            if (model.Active == "Add")
            {
                message = model.addCalendar();
            }
            if (model.Active!=null &&  model.Active.IndexOf("Edit") >= 0)
            {
                //message = model.editCalendar(model.Active.Split(',')[1]);
            }
            if (model.Active != null && model.Active.IndexOf("Delete") >= 0)
            {
                message = model.deleteCalendar(model.Active.Split(',')[1]);
            }
            return RedirectToAction("CalendarPage");
        }
    }
}
