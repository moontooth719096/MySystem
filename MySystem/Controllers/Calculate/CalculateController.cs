using MySystem.ViewModels.Calculate;
using System.Web.Mvc;

namespace MySystem.Controllers
{
    public class CalculateController : Controller
    {

        #region 抓樂霸T換算
        public ActionResult TorebaTPConvert()
        {
            string message = string.Empty;
            return View();
        }
        #endregion

        #region 匯率換算
        public ActionResult ExchangeRate()
        {
            string message = string.Empty;
            ExchangeRateViewModel model = new ExchangeRateViewModel();
            model.GetExchangeRate();
            return View(model);
        }
        #endregion

        #region 分帳換算
        public ActionResult AverageCostSharing()
        {
            string message = string.Empty;
            return View();
        }
        #endregion
    }
}
