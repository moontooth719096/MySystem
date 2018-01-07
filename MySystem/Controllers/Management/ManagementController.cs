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
            if (model.Active == "Edit")
            {
                //message = model.editCalendar();
            }
            if (model.Active == "Delete")
            {
                message = model.deleteCalendar();
            }
            return RedirectToAction("CalendarPage");
        }
    }
}
