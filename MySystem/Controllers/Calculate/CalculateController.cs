using MySystem.ViewModels.Calculate;
using System.Web.Mvc;

namespace MySystem.Controllers
{
    public class CalculateController : Controller
    {
        public ActionResult TorebaTPConvert()
        {
            string message = string.Empty;
            return View();
        }

        public ActionResult ExchangeRate()
        {
            string message = string.Empty;
            ExchangeRateViewModel model = new ExchangeRateViewModel();
            model.GetExchangeRate();
            return View(model);
        }
    }
}
