using MySystem.ViewModels.Calculate;
using MySystem.ViewModels.Information;
using System.Web.Mvc;

namespace MySystem.Controllers
{
    public class InformationController : Controller
    {
        #region 匯率換算
        public ActionResult AnimationDownloadDirectory()
        {
            string message = string.Empty;
            AnimationDownloadDirectoryViewModel model = new AnimationDownloadDirectoryViewModel();
            model.init();
            //model.SetAnimationALL();
            model.GetAnimationList();
            return View(model);
        }
        [HttpPost]
        public ActionResult AnimationDownloadDirectory(AnimationDownloadDirectoryViewModel model)
        {
            string message = string.Empty;
            model.init();
            model.SetNowselect();
            model.GetAnimationList();
            return View(model);
        }
        #endregion
    }
}
